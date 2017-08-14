using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BossBehaviour : MonoBehaviour {

    public float speed = 1.0f;
    public float distanceToPlayer = 2.0f;

    private Animator animator;

    private GameObject player;

	// Use this for initialization
	void Start () {
        animator = GetComponent<Animator>();
	}
	
	// Update is called once per frame
	void Update () {
        if (player) {
            float directionX = player.transform.position.x - transform.position.x;
            if (Mathf.Abs(directionX) >= distanceToPlayer)
            {
                animator.SetBool("IsWalking", true);
                transform.position += Vector3.right * (directionX) * speed * Time.deltaTime;
            }
            else {
                animator.SetBool("IsWalking", false);
            }
            if (directionX > 0)
            {
                Vector3 scale = transform.localScale;
                transform.localScale = new Vector3(-Mathf.Abs(scale.x), scale.y, scale.z);
            }
            else if (directionX < 0)
            {
                Vector3 scale = transform.localScale;
                transform.localScale = new Vector3(Mathf.Abs(scale.x), scale.y, scale.z);
            }
        }
	}

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.CompareTag("Player")) {
            player = collision.gameObject;
        }
    }

    private void OnTriggerExit2D(Collider2D collision)
    {
        if (collision.CompareTag("Player")) {
            player = null;
            animator.SetBool("IsWalking", false);
        }
    }
}
