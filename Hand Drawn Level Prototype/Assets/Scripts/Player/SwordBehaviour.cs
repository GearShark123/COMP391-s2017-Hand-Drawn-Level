using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SwordBehaviour : MonoBehaviour
{

    public float timeToDestroy = 5.0f;
    public float speed = 1.0f;
    public float damage;
    

    private GameManagerBehaviour gameManager;
    private new Collider2D collider;
    private new Rigidbody2D rigidbody;
    // Use this for initialization
    void Start()
    {
        Destroy(this.gameObject, timeToDestroy);
        gameManager = GameObject.FindObjectOfType<GameManagerBehaviour>();
        collider = GetComponent<Collider2D>();
        rigidbody = GetComponent<Rigidbody2D>();
        rigidbody.velocity = transform.right.normalized * speed;
    }
    

    void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.collider.tag == "Player" || collision.collider.tag == "IgnorePortal")
            return;
        
        rigidbody.velocity = Vector3.zero;
        collider.enabled = false;

        this.transform.parent = collision.transform;
        if (collision.collider.tag =="Enemy")
        {
            Health health = collision.gameObject.GetComponent<Health>();
            health.DamageTaken(damage, 0.0f, () => {
                    if (gameManager) gameManager.KilledEnemy();
                    Destroy(collision.gameObject);
                });
        }
    }
}
