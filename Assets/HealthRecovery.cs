using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HealthRecovery : MonoBehaviour
{
    private bool hasPlayer;
    private bool alreadyRecover;
    private float hp;

    public PlayerHealth health;

    // Start is called before the first frame update
    void Start()
    {
        hasPlayer = false;
        alreadyRecover = false;
    }

    // Update is called once per frame
    void Update()
    {
        hp = PlayerHealth.health;
        if (hasPlayer & !alreadyRecover)
        {
            if (hp < 5)
            {
                PlayerHealth.health += 2;
            }
            else if (hp >= 5 && hp < 6)
            {
                PlayerHealth.health += 1;
            }
            alreadyRecover = true;
        }
    }

    void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.name == "Player")
        {
            hasPlayer = true;
        }
    }
}
