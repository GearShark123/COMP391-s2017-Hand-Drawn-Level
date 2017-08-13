using System;
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
    private float touchDamage;

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
        touchDamage = gun.projectile.GetComponent<EnemyProjectileBehaviour>().damage;
    }

    void FixedUpdate()
    {
        if (isWalking)
        {
            //if it is going to the right
            if (direction.Equals(Vector2.right))
            {
                //if it is beyond the limit
                if (positionRight.position.x < transform.position.x) {
                    GoToLeft();
                }
            }
            //if it is going to the left
            if (direction.Equals(Vector2.left))
            {
                if (positionLeft.position.x > transform.position.x) {
                    GoToRight();
                }
            }
            transform.position += (Vector3)direction * speed * Time.deltaTime;
        }
    }

    private void GoToLeft()
    {
        direction = Vector2.left;//invert direction
        transform.localScale = new Vector3(-Mathf.Abs(transform.localScale.x), transform.localScale.y, transform.localScale.z);
        //The following code is necessary to make the gun rotate/position correctly
        gunJoint.localScale = new Vector3(-Mathf.Abs(gunJoint.localScale.x), gunJoint.localScale.y, gunJoint.localScale.z);
        gunJoint.rotation = Quaternion.Euler(0, 0, 180);
    }
    private void GoToRight()
    {
        direction = Vector2.right;//invert direction
        transform.localScale = new Vector3(Mathf.Abs(transform.localScale.x), transform.localScale.y, transform.localScale.z);
        //The following code is necessary to make the gun rotate/position correctly
        gunJoint.localScale = new Vector3(Mathf.Abs(gunJoint.localScale.x), gunJoint.localScale.y, gunJoint.localScale.z);
        gunJoint.rotation = Quaternion.Euler(0, 0, 0);
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

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.CompareTag("Player"))
        {
            Health health = collision.gameObject.GetComponent<Health>();
            health.DamageTaken(touchDamage, 0.0f, () => Destroy(collision.gameObject));
        }
    }
}
