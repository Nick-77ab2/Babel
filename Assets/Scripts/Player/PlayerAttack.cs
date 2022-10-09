using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerAttack : MonoBehaviour
{
    private PlayerMovement _playerMovement;
    private Animator _animator;
    public Transform attackPoint;
    public GameObject spell;
    public float attackSpeed = 2;
    public static float attackPower = 1;

    private float _timeToAttack;

    void Start(){
        _playerMovement = GetComponent<PlayerMovement>();
        _animator = _playerMovement.animator;
    }

    // Update is called once per frame
    void Update()
    {
        _timeToAttack -= Time.deltaTime;
        if (Input.GetKeyDown(KeyCode.Z) && _timeToAttack <= 0f)
        {
            //FireSpell();
            _animator.SetTrigger("cast");
            _timeToAttack = attackSpeed;
        }
    }

    public void FireSpell()
    {
        Debug.Log("Fire!");
        Instantiate(spell, attackPoint.position, attackPoint.rotation);
    }
}
