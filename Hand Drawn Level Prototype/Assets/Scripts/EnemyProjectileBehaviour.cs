using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyProjectileBehaviour : MonoBehaviour
{

    public float timeToDestroy = 5.0f;
    public float speed = 1.0f;
    public float damage;

    private float timeLimit = 3f;
    private float timeAdded = 0.1f;
    private float time;

    // Use this for initialization
    void Start()
    {
        Destroy(this.gameObject, timeToDestroy);
    }

    void Update()
    {
        time += timeAdded;

        if (time >= timeLimit)
        {
            Destroy(this.gameObject);
        }
    }

    // Update is called once per frame
    void FixedUpdate()
    {
        Vector3 direction = transform.right.normalized;
        transform.position += direction * speed * Time.deltaTime;
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        HandlePlayerCollision(collision);
    }

    private void OnTriggerExit2D(Collider2D collision)
    {
        HandlePlayerCollision(collision);
    }

    private void OnTriggerStay2D(Collider2D collision)
    {
        HandlePlayerCollision(collision);
    }

    private void HandlePlayerCollision(Collider2D collision)
    {
        if (collision.CompareTag("Player"))
        {
            Health health = collision.GetComponent<Health>();
            health.DamageTaken(damage, 0.0f, () => Destroy(collision.gameObject));
            Destroy(this.gameObject);
        }
    }
}
