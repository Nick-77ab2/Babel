using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BatMovement : MonoBehaviour
{
    private enum STATE { WANDER, CHASE, ATTACK, DIE };

    public GameObject display;
    public Animator animator;

    public float wanderSpeed;
    public float chaseSpeed;
    public float backwardDistance;
    public float forwardDistance;
    public LayerMask willAttackLayer;
    public float sightDistance;
    public float strikeDistance;
    public bool faceRight = true;
    public float attackPower;
    public float attackSpeed;
    public float rotationSpeed;
    private Vector3 originalPos;

    private Rigidbody2D _batRigidBody2D;
    private STATE _currentState;
    private Vector3 _currentPos;
    private float _maxWanderDistance;
    private float _minWanderDistance;
    private Vector2 _currentDirection;
    private GameObject _currentTarget;
    private float _timeToAttack;


    // Start is called before the first frame update
    void Start()
    {
        _batRigidBody2D = GetComponent<Rigidbody2D>();
        EnterStateWander();
        originalPos = transform.position;
        _minWanderDistance = originalPos.x - backwardDistance;
        _maxWanderDistance = originalPos.x + forwardDistance;
    }

    // Update is called once per frame
    void Update()
    {
        switch (_currentState)
        {
            case STATE.WANDER:
                UpdateWander();
                break;
            case STATE.ATTACK:
                UpdateAttack();
                break;
            case STATE.CHASE:
                UpdateChase();
                break;
            case STATE.DIE:
                UpdateDie();
                break;
        }
    }

    private void EnterStateWander()
    {
        _currentState = STATE.WANDER;
        if (faceRight)
        {
            _currentDirection = new Vector2(1f, 0);
        }
        else
        {
            _currentDirection = new Vector2(-1f, 0);
        }
    }

    private void UpdateWander()
    {
        _batRigidBody2D.velocity = _currentDirection * wanderSpeed;
        _currentPos = transform.position;
        if (_currentPos.x >= _maxWanderDistance && faceRight)
        {
            Flip();
            EnterStateWander();
        }
        if (_currentPos.x <= _minWanderDistance && !faceRight)
        {
            Flip();
            EnterStateWander();
        }

        RaycastHit2D hit = Physics2D.Raycast(transform.position, _currentDirection, sightDistance, willAttackLayer.value);
        if (hit.collider != null)
        {
            EnterStateChase(hit.collider.gameObject);
        }
    }

    private void EnterStateChase(GameObject target)
    {
        _currentState = STATE.CHASE;
        _currentTarget = target;
        if (_currentTarget.transform.position.x <= transform.position.x)
        {
            if (faceRight)
            {
                Flip();
            }
        }
        else if (_currentTarget.transform.position.x > transform.position.x)
        {
            if (!faceRight)
            {
                Flip();
            }
        }
        _currentDirection = (target.transform.position - transform.position).normalized;
    }

    private void UpdateChase()
    {
        Vector2 targetDirection = (_currentTarget.transform.position - transform.position).normalized;
        _currentDirection = Vector3.RotateTowards(_currentDirection.normalized, targetDirection, rotationSpeed * Mathf.Deg2Rad * Time.deltaTime, 0f).normalized;
        _batRigidBody2D.velocity = _currentDirection * chaseSpeed;
        //animor here

        float targetDistance = Vector3.Distance(_currentTarget.transform.position, transform.position);

        if (targetDistance <= strikeDistance)
        {
            EnterStateAttack();
        }
        else if (targetDistance > sightDistance)
        {
            _currentState = STATE.WANDER;
        }
    }

    private void EnterStateAttack()
    {
        _currentState = STATE.ATTACK;
        _batRigidBody2D.velocity = Vector2.zero;
        //animator.SetTrigger("attack");

    }

    private void UpdateAttack()
    {
        _timeToAttack -= Time.deltaTime;
        if (_timeToAttack <= 0f)
        {
            DoAttack();
            _timeToAttack = attackSpeed;
        }
    }

    public void DoAttack()
    {
        RaycastHit2D hit = Physics2D.Raycast(transform.position, _currentDirection, strikeDistance, willAttackLayer.value);
        if (hit.collider != null)
        {
            if (hit.collider.gameObject.GetComponent<PlayerHealth>() != null)
            {
                hit.collider.gameObject.GetComponent<PlayerHealth>().GetHit(attackPower);
            }
        }
        EnterStateChase(_currentTarget);
    }

    public void AttackOver()
    {

    }

    public void Die()
    {
        EnterStateDie();
    }

    private void EnterStateDie()
    {
        _currentState = STATE.DIE;
        //animator.SetTrigger("die");
        _batRigidBody2D.velocity = Vector2.zero;
        GetComponent<Collider2D>().enabled = false;
    }

    private void UpdateDie()
    {
        //if (animator.GetComponent<SpriteRenderer>().sprite == null)
        //{
        Destroy(gameObject);
        //}
    }

    private void Flip()
    {
        faceRight = !faceRight;
        //display.GetComponent<SpriteRenderer>().flipX = false;
        //display.GetComponent<SpriteRenderer>().flipY = true;
        transform.Rotate(0f, 180f, 0f);
    }
}
