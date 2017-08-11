using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PortalExitBehaviour : MonoBehaviour {

    [HideInInspector]
    public float distance;
    public float speed = 10.0f;
    public float timeToDestroy = 0.7f;

    private Vector3 initialPosition;
    private bool canMove;

    public GameObject Player { get; internal set; }

    // Use this for initialization
    void Start () {
        initialPosition = transform.position;
        canMove = true;
        Destroy(this.gameObject, timeToDestroy);
	}
	
	// Update is called once per frame
	void FixedUpdate () {
        if ((transform.position - initialPosition).magnitude < distance && canMove)
            transform.position += transform.right.normalized * speed * Time.deltaTime;
        else
        {
            if (Player)
            {
                Player.SetActive(true);
                Rigidbody2D rb = Player.GetComponent<Rigidbody2D>();
                Vector2 velocity = rb.velocity;
                rb.velocity = Vector2.right * velocity.x;
                if ((transform.position - initialPosition).magnitude > 0.0f)
                {
                    Player.transform.position = transform.position + transform.right.normalized;
                }
            }
        }
	}

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (!collision.CompareTag("Player") && !collision.CompareTag("Portal") && !collision.CompareTag("IgnorePortal"))
        {
            canMove = false;
        }

    }
}
