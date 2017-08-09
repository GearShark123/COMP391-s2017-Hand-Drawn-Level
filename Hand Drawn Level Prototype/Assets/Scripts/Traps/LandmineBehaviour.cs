using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LandmineBehaviour : MonoBehaviour {
    public GameObject manager;
    public GameObject landmine;
    public GameObject explosion;

    public float damage;        // 5

    #region _PlayerCollision_
    private void PlayerCollision(Collider2D collision)
    {
        // print(time);
        if ((collision.CompareTag("Player") || collision.CompareTag("Enemy")))
        {
            Health health = collision.GetComponent<Health>();
            health.DamageTaken(damage, 0.0f, () => Destroy(collision.gameObject));
            //time = 0.0f;
        }
    }
    #endregion

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.name == "Player")
        {
            PlayerCollision(collision);
            Destroy(landmine);
            Instantiate(explosion, manager.transform);
        }
    }   
}
