using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpikeBehaviour : MonoBehaviour {

    public float damage;        // 1
    public float timeLimit;     // 3
    public float addTime;       // 0.5
    public float time;          // 3

    #region _PlayerCollision_
    private void PlayerCollision(Collider2D collision)
    {
        // print(time);
        if (time >= timeLimit && (collision.CompareTag("Player") || collision.CompareTag("Enemy")))
        {
            Health health = collision.GetComponent<Health>();
            health.DamageTaken(damage, 0.0f, () => Destroy(collision.gameObject));
            time = 0.0f;
        }
    }
    #endregion

    private void OnTriggerEnter2D(Collider2D collision)
    {
        PlayerCollision(collision);
    }

    private void OnTriggerExit2D(Collider2D collision)
    {
        PlayerCollision(collision);
    }

    private void OnTriggerStay2D(Collider2D collision)
    {
        PlayerCollision(collision);
    }

    void Update()
    {
        time += addTime;
    }
}
