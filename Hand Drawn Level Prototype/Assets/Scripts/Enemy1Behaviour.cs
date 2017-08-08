using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemy1Behaviour : MonoBehaviour {

    public Transform positionA;
    public Transform positionB;
    public float speed;

    private Animator animator;
    private Vector2 direction;
    public bool isWalking;

	// Use this for initialization
	void Start () {
        animator = GetComponent<Animator>();
        direction = (Vector2)Vector3.Project(positionA.position - transform.position, Vector3.right).normalized;
        positionB.parent = null;
        positionA.parent = null;
	}

    void FixedUpdate()
    {
        if (isWalking)
        {
            transform.position += (Vector3)direction * speed * Time.deltaTime;
        }
        animator.SetBool("IsWalking", isWalking);
    }

    // Update is called once per frame
    void Update () {
        //if it is close from one of the points
        if ((transform.position - positionA.position).magnitude < 0.2f || (transform.position - positionB.position).magnitude < 0.2f) {
            direction *= -1;//invert direction
            transform.localScale = new Vector3(-transform.localScale.x, transform.localScale.y, transform.localScale.z);
        }
	}
}
