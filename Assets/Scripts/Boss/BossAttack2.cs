using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BossAttack2 : MonoBehaviour
{
    public Transform attackPoint_1;
    public Transform attackPoint_2;
    public Transform attackPoint_3;
    public Transform attackPoint_4;
    public Transform attackPoint_5;
    public Transform attackPoint_6;
    public Transform attackPoint_7;
    public Transform attackPoint_8;
    public GameObject player;
    public GameObject horizontal_spell_left;
    public GameObject horizontal_spell_right;
    public GameObject vertical_spell;
    public float attackSpeed = 2;

    private float _timeToAttack;
    private int counter = 0;

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
            FireSpell_2();
            _timeToAttack = attackSpeed;
        }
    }

    public void FireSpell_1()
    {
        Instantiate(horizontal_spell_left, attackPoint_1.position, attackPoint_1.rotation);
        Instantiate(horizontal_spell_left, attackPoint_2.position, attackPoint_2.rotation);
        //Instantiate(horizontal_spell_1, attackPoint_3.position, attackPoint_3.rotation);
        Instantiate(horizontal_spell_right, attackPoint_4.position, attackPoint_4.rotation);
        Instantiate(horizontal_spell_right, attackPoint_5.position, attackPoint_5.rotation);
        //Instantiate(horizontal_spell_2, attackPoint_6.position, attackPoint_6.rotation);
    }

    public void FireSpell_2()
    {
        Instantiate(vertical_spell, attackPoint_7.position, attackPoint_7.rotation);
        Instantiate(vertical_spell, attackPoint_8.position, attackPoint_8.rotation);
    }
}
