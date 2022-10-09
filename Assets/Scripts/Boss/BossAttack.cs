using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BossAttack : MonoBehaviour
{
    public Transform attackPoint;
    public GameObject player;
    public GameObject spell_1;
    public float attackSpeed = 2;

    private float _timeToAttack;

    // Start is called before the first frame update
    void Start()
    {
    
    }

    // Update is called once per frame
    void Update()
    {
        _timeToAttack -= Time.deltaTime;
        if (_timeToAttack <= 0f)
        {
            FireSpell_1();
            _timeToAttack = attackSpeed;
        }
    }

    public void FireSpell_1()
    {
        Instantiate(spell_1, attackPoint.position, attackPoint.rotation);
    }
}
