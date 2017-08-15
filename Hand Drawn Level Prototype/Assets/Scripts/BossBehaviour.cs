using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BossBehaviour : MonoBehaviour {

    public float speed = 1.0f;
    public float minDistanceToPlayer = 2.0f;
    public float maxDistanceToPlayer = 25.0f;
    public float maxDistanceFromDungeon = 30;

    private Animator animator;
    private Vector3 initialPosition;

    private CheckPointBehaviour checkpoint;
    private GameManagerBehaviour gameManager;

	// Use this for initialization
	void Start () {
        animator = GetComponent<Animator>();
        checkpoint = GameObject.FindObjectOfType<CheckPointBehaviour>();
        initialPosition = transform.position;
        gameManager = GameObject.FindObjectOfType<GameManagerBehaviour>();
	}
	
	// Update is called once per frame
	void Update () {
        if (checkpoint.currentPlayer != null) {
            float directionX = checkpoint.currentPlayer.transform.position.x - transform.position.x;
            if (directionX < 0 && (transform.position - initialPosition).magnitude > maxDistanceFromDungeon)
            {
                animator.SetBool("IsWalking", false);
                return;
            }
            if (Mathf.Abs(directionX) >= minDistanceToPlayer && Mathf.Abs(directionX) <= maxDistanceToPlayer)
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

    private void OnDestroy()
    {
        gameManager.FinishGame();
    }
}
