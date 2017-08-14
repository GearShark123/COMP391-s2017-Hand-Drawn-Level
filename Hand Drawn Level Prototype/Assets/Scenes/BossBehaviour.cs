using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BossBehaviour : MonoBehaviour {

    public float speed = 1.0f;

    private Animator animator;

    private GameObject player;

	// Use this for initialization
	void Start () {
        animator = GetComponent<Animator>();
	}
	
	// Update is called once per frame
	void Update () {
        if (player) {
            animator.SetBool("IsWalking", true);
            transform.position += Vector3.right * (player.transform.position.x - transform.position.x) * speed * Time.deltaTime;
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
