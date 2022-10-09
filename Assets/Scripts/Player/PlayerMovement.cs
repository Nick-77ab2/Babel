using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMovement : MonoBehaviour
{
    public GameObject display;
    public Animator animator;
    public float moveSpeed = 2;
    public float jumpForce = 3;
    public float jumpInterval = 3;
    public float doubleJumpForce = 2;
    bool faceRight = true;

    private Rigidbody2D _playerRigidBody2D;
    private float _timeToJump;
    private bool _jumpOnce = false;

    // Start is called before the first frame update
    void Start()
    {
        _playerRigidBody2D = GetComponent<Rigidbody2D>();
    }

    // Update is called once per frame
    void Update()
    {
        Vector3 oldPosition = transform.position;
        _timeToJump -= Time.deltaTime;
        if (Input.GetKey(KeyCode.RightArrow))
        {
            if (!faceRight)
            {
                Flip();
            }
            transform.position += new Vector3(1, 0, 0) * Time.deltaTime * moveSpeed;
        }
        else if (Input.GetKey(KeyCode.LeftArrow))
        {
            if (faceRight)
            {
                Flip();
            }
            transform.position += new Vector3(-1, 0, 0) * Time.deltaTime * moveSpeed;
        }
        animator.SetFloat("speed",Mathf.Abs(oldPosition.x-transform.position.x));

        if (Input.GetKeyDown(KeyCode.Space))
        {
            Jumping();
        }

        if  (Mathf.Abs(_playerRigidBody2D.velocity.y) < 0.001f)
        {
            _jumpOnce = false;
        }

        /*if (Input.GetKeyDown(KeyCode.Space) && Mathf.Abs(_playerRigidBody2D.velocity.y) < 0.001f && && _timeToJump <= 0f)
        {
            _playerRigidBody2D.AddForce(new Vector2(0, jumpForce), ForceMode2D.Impulse);
            _timeToJump = jumpInterval;
        }*/
    }

    private void Flip()
    {
        faceRight = !faceRight;
        
        transform.Rotate(0f, 180f, 0f);
    }

    public void Jumping(){
         if (_jumpOnce)
            {
                _playerRigidBody2D.velocity = Vector2.zero;
                _playerRigidBody2D.angularVelocity = 0f;
                _playerRigidBody2D.AddForce(new Vector2(0, doubleJumpForce), ForceMode2D.Impulse);
                _timeToJump = jumpInterval;
                _jumpOnce = !_jumpOnce;
            }
            else if (_timeToJump <= 0f && Mathf.Abs(_playerRigidBody2D.velocity.y) < 0.001f)
            {
                animator.SetTrigger("jump");
                _playerRigidBody2D.AddForce(new Vector2(0, jumpForce), ForceMode2D.Impulse);
                _jumpOnce = true;
                _timeToJump = jumpInterval;
            }
            //_timeToJump = jumpInterval;
            //_jumpOnce = !_jumpOnce;
    }
}
