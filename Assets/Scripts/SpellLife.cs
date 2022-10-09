using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpellLife : MonoBehaviour
{
    public float flyingDistance;
    public float speed;
    public Rigidbody2D spell;

    private Vector3 spawnPos;
    
    // Start is called before the first frame update
    void Start()
    {
        spell.velocity = transform.right * speed;
        spawnPos = transform.position;
    }

    // Update is called once per frame
    void Update()
    {
        if (Vector3.Distance(spawnPos, transform.position) >= flyingDistance)
        {
            Destroy(gameObject);
        }
    }

    void OnCollisionEnter2D(Collision2D collision)
    {
        Destroy(gameObject);
    }
}
