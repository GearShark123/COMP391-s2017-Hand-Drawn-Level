using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SwordBehaviour : MonoBehaviour
{

    public float timeToDestroy = 5.0f;
    public float speed = 1.0f;
    public float damage;
    private bool hit;
    
    private GameManagerBehaviour gameManager;
    private new Collider2D collider;
    // Use this for initialization
    void Start()
    {
        Destroy(this.gameObject, timeToDestroy);
        hit = false;
        gameManager = GameObject.FindObjectOfType<GameManagerBehaviour>();
        collider = GetComponent<Collider2D>();
    }

    // Update is called once per frame
    void Update()
    {
        if (hit == false)
        {
            Vector3 direction = transform.right.normalized;
            transform.position += direction * speed * Time.deltaTime;
        }
    }

    void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.collider.tag == "Player" || collision.collider.tag == "IgnorePortal")
            return;

        hit = true;
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
