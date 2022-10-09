using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MovePlatform : MonoBehaviour
{
    public float minDistance;
    public float maxDistance;
    public float moveSpeed = 0.7f;

    private float _currentDirection;
    private GameObject _target;
    private GameObject _target2;
    // Start is called before the first frame update
    void Start()
    {
        _currentDirection = 1f;
    }

    // Update is called once per frame
    void Update()
    {
        transform.position += new Vector3(0, _currentDirection, 0) * Time.deltaTime * moveSpeed;
        if (_target != null)
        {
            _target.transform.position += new Vector3(0, _currentDirection, 0) * Time.deltaTime * moveSpeed;
        }

        if (_target2 != null)
        {
            _target2.transform.position += new Vector3(0, _currentDirection, 0) * Time.deltaTime * moveSpeed;
        }

        if (transform.position.y >= maxDistance)
        {
            _currentDirection = -1f;
        }
        else if (transform.position.y <= minDistance)
        {
            _currentDirection = 1f;
        }
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.name != "spell(Clone)" && collision.gameObject.name != "Player")
        {
            _target = collision.gameObject;
        }

        if (collision.gameObject.name == "Player")
        {
            _target2 = collision.gameObject;
        }
    }

    private void OnCollisionExit2D(Collision2D collision)
    {
        if (collision.gameObject.name != "spell(Clone)" && collision.gameObject.name == "Player")
        {
            _target2 = null;
        }
    }
}
