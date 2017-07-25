using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerControls : MonoBehaviour 
{
    [SerializeField]
    public float Speed = 10.0f;
    [SerializeField]
    public float jumpSpeed = 0.2f;
    private float myTime = 1.0f;
    private const float nextJump = 1.0f;
    public LayerMask GroundLayers;

    private Animator myAnimator;
    private Transform myGroundCheck;
    private SpriteRenderer spriteRenderer;

    void Start()
    {
        myAnimator = GetComponent<Animator>();
        // The Transform attached to this GameObject.
        myGroundCheck = transform.FindChild("GroundCheck");
        spriteRenderer = GetComponent<SpriteRenderer>();
    }

    void FixedUpdate()
    {
        //print(myTime);
        myTime += Time.deltaTime;
        bool isGrounded = Physics2D.OverlapPoint(myGroundCheck.position, GroundLayers);
        myAnimator.SetBool("IsGrounded", isGrounded);

        if (Input.GetButton("Jump") && myTime > nextJump)
        {
            GetComponent<Rigidbody2D>().AddForce(Vector2.up * jumpSpeed, ForceMode2D.Impulse);
            isGrounded = false;            
            myTime = 0.0f;
        }   

        // Returns the value of the virtual axis identified by axisName.
        float hSpeed = Input.GetAxis("Horizontal")*Speed;
        // Object move
        GetComponent<Rigidbody2D>().velocity = new Vector2(hSpeed, GetComponent<Rigidbody2D>().velocity.y);
        // Animation walk
        myAnimator.SetFloat("Speed", Mathf.Abs(hSpeed));  // Mathf.Abs - Returns the absolute value of f.

        // Turn sprite left
        if (hSpeed < 0)
        {
            spriteRenderer.flipX = true;
        }
        // Turn sprite right
        else if (hSpeed > 0)
        {
            spriteRenderer.flipX = false;
        }

    }

}

