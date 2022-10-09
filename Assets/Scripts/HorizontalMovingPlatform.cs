using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HorizontalMovingPlatform : MonoBehaviour
{
    public float minDistance;
    public float maxDistance;
    public float moveSpeed = 0.7f;

    private float _currentDirection;
    private GameObject _target;
    // Start is called before the first frame update
    void Start()
    {
        _currentDirection = 1f;
    }

    // Update is called once per frame
    void Update()
    {
        transform.position += new Vector3(_currentDirection, 0, 0) * Time.deltaTime * moveSpeed;
        if (_target != null)
        {
            _target.transform.position += new Vector3(_currentDirection, 0, 0) * Time.deltaTime * moveSpeed;
        }

        if (transform.position.x >= maxDistance)
        {
            _currentDirection = -1f;
        }
        else if (transform.position.x <= minDistance)
        {
            _currentDirection = 1f;
        }
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.name != "spell(Clone)")
        {
            _target = collision.gameObject;
        }
    }

    private void OnCollisionExit2D(Collision2D collision)
    {
        if (collision.gameObject.name != "spell(Clone)")
        {
            _target = null;
        }
    }
}
