using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemy1Behaviour : MonoBehaviour {

    public Transform positionRight;
    public Transform positionLeft;
    public float speed;

    private Animator animator;
    private Vector2 direction;
    private bool isWalking;
    private GunBehaviour gun;
    private Transform gunJoint;

	// Use this for initialization
	void Start () {
        animator = GetComponent<Animator>();
        direction = (Vector2)Vector3.Project(positionRight.position - transform.position, Vector3.right).normalized;
        positionLeft.parent = null;
        positionRight.parent = null;
        InvokeRepeating("Walk", 0.000001f, 2.5f);
        InvokeRepeating("Shoot", 0.000001f, 0.5f);
        InvokeRepeating("Stop", 2.1f, 2.5f);
        gun = GetComponentInChildren<GunBehaviour>();
        gunJoint = gun.transform.parent;
    }

    void FixedUpdate()
    {
        if (isWalking)
        {
            //if it crosses one of the points
            if (positionRight.position.x < transform.position.x || positionLeft.position.x > transform.position.x)
            {
                direction *= -1;//invert direction
                //This kind of code is one of the reasons I avoid negative scales.
                transform.localScale = new Vector3(-transform.localScale.x, transform.localScale.y, transform.localScale.z);
                //The following code is necessary to make the gun rotate/position correctly
                gunJoint.localScale = new Vector3(-gunJoint.localScale.x, gunJoint.localScale.y, gunJoint.localScale.z);
                gunJoint.Rotate(Vector3.forward * 180.0f, Space.World);
            }
            transform.position += (Vector3)direction * speed * Time.deltaTime;
        }
    }

    private void Walk()
    {
        isWalking = true;
        animator.SetBool("IsWalking", isWalking);
    }
    private void Stop()
    {
        isWalking = false;
        animator.SetBool("IsWalking", isWalking);
    }
    private void Shoot() {
        gun.Shoot();
    }
}
