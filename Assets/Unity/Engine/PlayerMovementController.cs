using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMovementController : MonoBehaviour
{

    [Header("Setters")] 
    public float speed;
    public float jumpIntensity;

    [Header("Components")] 
    public Animator animator;
    
    private Rigidbody2D _rigidbody2D;
    private Joystick _joystick;
    
    private bool _isOnGround;
    private bool _isJumping;
    
    void Start()
    {
        _joystick = GameManager.instance.UIManager.joystick;
        _rigidbody2D = GetComponent<Rigidbody2D>();
    }

   
    void Update()
    {
        float horizontalMovement = _joystick.Horizontal;
        float verticalMovement = _joystick.Vertical;

        // Apply the movement to the player
        _rigidbody2D.velocity = new Vector2(horizontalMovement * speed, _rigidbody2D.velocity.y);

        // Animate Movement
        if (horizontalMovement != 0 && _isOnGround)
        {
            animator.SetBool(Constants.WalkBool, true);
        }
        else
        {
            animator.SetBool(Constants.WalkBool, false);
        }

        // Rotate
        if(horizontalMovement > 0)
            transform.localScale = new Vector3(1, 1, 1);
        else if(horizontalMovement < 0)
            transform.localScale = new Vector3(-1, 1, 1);
    }

    private void Move()
    {
        //Move
        _rigidbody2D.velocity = new Vector2(_joystick.Horizontal * speed, _rigidbody2D.velocity.y);
        
        //Animate Movement
        if (_joystick.Horizontal != 0 && _isOnGround)
        {
            animator.SetBool(Constants.WalkBool, true);
        }
        else
        {
            animator.SetBool(Constants.WalkBool, false);
        }
        
        //Rotate
        if(_joystick.Horizontal > 0)
            transform.localScale = new Vector3(1, 1, 1);
        else if(_joystick.Horizontal < 0)
            transform.localScale = new Vector3(-1, 1, 1);
    }
    public void TriggerJumpAnim()
    {
        if (!_isJumping && _isOnGround)
        {
            _isJumping = true;
            animator.SetTrigger(Constants.JumpTrigger);
            _rigidbody2D.AddForce(Vector2.up * jumpIntensity, ForceMode2D.Impulse);
        }
    }
    
    private void OnCollisionStay2D(Collision2D other)
    {
        if (other.gameObject.CompareTag(Constants.Ground))
        {
            animator.SetBool(Constants.IsOnGroundBool, true);
            _isOnGround = true;
            _isJumping = false;
        }
    }
    private void OnCollisionExit2D(Collision2D other)
    {
        if (other.gameObject.CompareTag(Constants.Ground))
        {
            animator.SetBool(Constants.IsOnGroundBool, false);
            _isOnGround = false;
        }
    }
}
