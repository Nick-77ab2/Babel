using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BossController : MonoBehaviour
{
    private enum STATE { WANDER, CHASE, ATTACK, DIE };

    public GameObject display;
    public Animator animator;
    public GameObject player;
    public float moveSpeed;
    public BossAttack attack_1;
    public BossAttack2 attack_2;
    public int int_attack_duration_1;
    public int int_attack_duration_2;

    public float minWanderDistance;
    public float maxWanderDistance;

    public bool faceRight = false;

    private Rigidbody2D _bossRigidBody2D;
    private STATE _currentState;
    private Vector3 _playerPos;
    private float _currentDirection;
    private Vector3 _currentPos;
    private float _moveToPosX;
    private bool _isMovingLeft = false;
    private bool _isMoving = false;
    public int attackType;

    // Start is called before the first frame update
    void Start()
    {
        _bossRigidBody2D = GetComponent<Rigidbody2D>();
        EnterStateWander();
    }

    // Update is called once per frame
    void Update()
    {
        _playerPos = player.transform.position;
        switch (_currentState)
        {
            case STATE.WANDER:
                UpdateWander();
                break;
            case STATE.ATTACK:
                UpdateAttack();
                break;
            case STATE.DIE:
                UpdateDie();
                break;
        }
    }

    private void EnterStateWander()
    {
        float _oldPos=transform.position.x;
        _currentState = STATE.WANDER;
        if (!_isMoving)
        {
            _moveToPosX = Random.Range(minWanderDistance, maxWanderDistance);
            animator.SetFloat("speed",Mathf.Abs(_oldPos-transform.position.x));
        }
        _currentPos = transform.position;
        if (_currentPos.x >= _moveToPosX && !_isMoving)
        {
            if (faceRight)
            {
                Flip();
            }
            _currentDirection = -1f;
            _isMovingLeft = true;
            
        }
        else if (_currentPos.x < _moveToPosX && !_isMoving)
        {
            if (!faceRight)
            {
                Flip();
            }
            _currentDirection = 1f ;
            _isMovingLeft = false;
        }
        _isMoving = true;
        animator.SetFloat("speed",Mathf.Abs(_oldPos-transform.position.x));
    }

    private void UpdateWander()
    {
        
        _currentPos = transform.position;
        if (_isMovingLeft && _currentPos.x >= _moveToPosX)
        {
            transform.position += new Vector3(_currentDirection, 0, 0) * Time.deltaTime * moveSpeed;
            //EnterStateWander();
        }
        else if (!_isMovingLeft && _currentPos.x <= _moveToPosX)
        {
            transform.position += new Vector3(_currentDirection, 0, 0) * Time.deltaTime * moveSpeed;
            //EnterStateWander();
        }
        else
        {
            EnterStateAttack();
            _isMoving = false;
        }
        animator.SetFloat("speed",Mathf.Abs(_currentPos.x-transform.position.x));
    }

    private void EnterStateAttack()
    {
        _currentPos = transform.position;
        if (_currentPos.x >= _playerPos.x && faceRight)
        {
            Flip();
        }
        else if (_currentPos.x < _playerPos.x && !faceRight)
        {
            Flip();
        }
        _currentState = STATE.ATTACK;
    }

    private void UpdateAttack()
    {
        attackType = Random.Range(0, 10);
        animator.SetTrigger("attack");
        Debug.Log("Got here");
        animator.SetBool("notAttack",false);

        if (attack_1.isActiveAndEnabled)
        {
            StartCoroutine(Wait_1(int_attack_duration_1));
        }
        else if (attack_2.isActiveAndEnabled)
        {
            StartCoroutine(Wait_2(int_attack_duration_2));
        }
    }

    public void DoAttack1()
    {
        //animator should be here
        attack_1.enabled = true;
    }

    public void DoAttack2()
    {
        //animator should be here
        attack_2.enabled = true;
    }

    private IEnumerator Wait_1(int seconds)
    {
        yield return new WaitForSeconds(seconds);
        attack_1.enabled = false;
        animator.SetBool("notAttack",true);
        EnterStateWander();
    }

    private IEnumerator Wait_2(int seconds)
    {
        yield return new WaitForSeconds(seconds);
        attack_2.enabled = false;
        animator.SetBool("notAttack",true);
        EnterStateWander();
    }


    public void Die()
    {
        EnterStateDie();
    }

    private void EnterStateDie()
    {
        _currentState = STATE.DIE;
        //animator.SetTrigger("die");
        _bossRigidBody2D.velocity = Vector2.zero;
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
        transform.Rotate(0f, 180f, 0f);
    }
}
