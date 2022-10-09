using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BossSpellLife_1 : MonoBehaviour
{
    public float flyingDistance;
    public float speed;
    public float power = 2;
    public Rigidbody2D spell;

    private Vector3 spawnPos;
    private GameObject player;

    // Start is called before the first frame update
    void Start()
    {
        spell.velocity = -1*transform.right * speed;
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
