using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SwordBehaviour : MonoBehaviour
{

    public float timeToDestroy = 5.0f;
    public float speed = 1.0f;
    public float damage;
    private bool hit;

    private float time;
    private float timeAdded = 0.1f;
    private float timeLimit = 0.2f;
    private GameManagerBehaviour gameManager;

    // Use this for initialization
    void Start()
    {
        Destroy(this.gameObject, timeToDestroy);
        hit = false;
        gameManager = GameObject.FindObjectOfType<GameManagerBehaviour>();
    }

    // Update is called once per frame
    void Update()
    {
        time += timeAdded;
        if (hit == false)
        {
            Vector3 direction = transform.right.normalized;
            transform.position += direction * speed * Time.deltaTime;
        }
    }

    void OnCollisionEnter2D(Collision2D collision)
    {        
        if (collision.collider.tag != "Player" && collision.collider.tag != "IgnorePortal")
        {
            //print(collision.collider);
            hit = true;
        }
        if (time >= timeLimit)
        {
            hit = true;
        }
        if (collision.collider.tag =="Enemy")
        {
            Health health = collision.gameObject.GetComponent<Health>();
            health.DamageTaken(damage, 0.0f, () => {
                    gameManager.KilledEnemy();
                    Destroy(collision.gameObject);
                });
            time = 0.0f;
        }
    }
}
