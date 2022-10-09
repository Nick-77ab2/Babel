using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerHealth : MonoBehaviour
{
    public static float health = 5;

    private PlayerMovement _playerMovement;
    private Rigidbody2D _playerRigidBody2D;
    private Animator _animator;
    // Start is called before the first frame update
    void Start()
    {
        _playerMovement = GetComponent<PlayerMovement>();
        _playerRigidBody2D = GetComponent<Rigidbody2D>();
        _animator = _playerMovement.animator;
    }

    public void GetHit(float hitPower)
    {
        health -= hitPower;
        _animator.SetTrigger("hurt");
        if (health <= 0)
        {
            _playerRigidBody2D.velocity = Vector2.zero;
            _playerMovement.enabled = false;
            //_animator.SetTrigger("die");
            //Destroy(gameObject);
        }
    }

    public void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.name.Contains("BossSpell_1"))
        {
            float hitPower = collision.gameObject.GetComponent<BossSpellLife_1>().power;
            Debug.Log(hitPower);
            GetHit(hitPower);
        }

        if (collision.gameObject.name.Contains("BossSpell_2"))
        {
            float hitPower = collision.gameObject.GetComponent<BossSpellLife_2>().power;
            Debug.Log(hitPower);
            GetHit(hitPower);
        }

        if (collision.gameObject.name.Contains("BossSpell_3"))
        {
            float hitPower = collision.gameObject.GetComponent<BossSpellLife_3>().power;
            Debug.Log(hitPower);
            GetHit(hitPower);
        }

        if (collision.gameObject.name.Contains("BossSpell_4"))
        {
            float hitPower = collision.gameObject.GetComponent<BossSpellLife_1>().power;
            Debug.Log(hitPower);
            GetHit(hitPower);
        }
    }

}
