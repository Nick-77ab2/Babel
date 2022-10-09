using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BossHealth : MonoBehaviour
{
    public float health = 10;
    public BossController controller;
    private float damageAmount;

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.collider.gameObject.name.Contains("spell"))
        {
            damageAmount = PlayerAttack.attackPower;
            TakeDamage(damageAmount);
        }
    }

    private void TakeDamage(float damageAmount)
    {
        health -= damageAmount;
        if (health <= 0)
        {
            controller.Die();
        }
    }
}
