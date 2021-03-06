﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerControls : MonoBehaviour
{
    public float speed = 10.0f;
    public float jumpSpeed = 0.2f;
    public LayerMask GroundLayers;

    private float myTime = 1.0f;
    private const float nextJump = 1.0f;
    private Animator myAnimator;
    private Transform myGroundCheck;
    private SpriteRenderer playerSpriteRenderer;
    private SpriteRenderer armSpriteRenderer;
    private Transform armJoint;
    private GunBehaviour gun;
    private float hSpeed = 0.0f;

    void Start()
    {
        myAnimator = GetComponent<Animator>();
        // The Transform attached to this GameObject.
        myGroundCheck = transform.Find("GroundCheck");
        playerSpriteRenderer = GetComponent<SpriteRenderer>();
        armJoint = transform.Find("Joint");
        if (armJoint)
        {
            gun = armJoint.GetComponentInChildren<GunBehaviour>();
            armSpriteRenderer = gun.GetComponent<SpriteRenderer>();
        }
    }

    private void Update()
    {
        UpdateArm();
    }

    void FixedUpdate()
    {
        //print(myTime);
        myTime += Time.deltaTime;
        bool isGrounded = Physics2D.OverlapPoint(myGroundCheck.position, GroundLayers);
        myAnimator.SetBool("isGrounded", isGrounded);

        if (Input.GetKey(KeyCode.W) && myTime > nextJump && isGrounded)
        {
            GetComponent<Rigidbody2D>().AddForce(Vector2.up * jumpSpeed, ForceMode2D.Impulse);
            isGrounded = false;
            myTime = 0.0f;
        }

        // Returns the value of the virtual axis identified by axisName.
        hSpeed = Input.GetAxis("Horizontal") * speed;
        // Object move
        GetComponent<Rigidbody2D>().velocity = new Vector2(hSpeed, GetComponent<Rigidbody2D>().velocity.y);
        // Animation walk
        myAnimator.SetFloat("speed", Mathf.Abs(hSpeed));  // Mathf.Abs - Returns the absolute value of f.

        // Turn sprite left
        if (hSpeed < 0)
        {
            playerSpriteRenderer.flipX = true;
            armSpriteRenderer.flipX = true;
        }
        // Turn sprite right
        else if (hSpeed > 0)
        {
            playerSpriteRenderer.flipX = false;
            armSpriteRenderer.flipX = false;
        }
    }

    private void UpdateArm()
    {
        if (armJoint)
        {
            Vector3 mousePosition = Camera.main.ScreenToWorldPoint(new Vector3(Input.mousePosition.x, Input.mousePosition.y, 10));
            Vector3 direction = mousePosition - transform.position;

            float mouseAngle = Mathf.Atan2(direction.y, direction.x);
            float cosAngle = Mathf.Cos(mouseAngle);

            if (cosAngle != 0)
            {
                playerSpriteRenderer.flipX = cosAngle < 0;
                armSpriteRenderer.flipX = playerSpriteRenderer.flipX;
            }

            bool isReverse = hSpeed > 0 && cosAngle < 0 || hSpeed < 0 && cosAngle > 0;          
            myAnimator.SetBool("isReverse", isReverse);

            armJoint.localRotation = Quaternion.Euler(0, 0, Mathf.Rad2Deg * mouseAngle);
            Debug.DrawRay(transform.position, direction);

            gun.Aim(Input.GetButton("Fire1"));

            if (Input.GetButtonUp("Fire1"))
            {
                gun.Shoot();
            }
        }
    }
}

