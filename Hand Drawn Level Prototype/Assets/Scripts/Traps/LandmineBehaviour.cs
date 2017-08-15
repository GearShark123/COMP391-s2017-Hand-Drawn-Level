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
        if (collision.CompareTag("Player"))
        {
            Health health = collision.GetComponent<Health>();
            health.DamageTaken(damage, 0.0f, () => Destroy(collision.gameObject));
        }
    }
    #endregion

    void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.name == "Player" || collision.gameObject.name == "Player(Clone)")
        {
            PlayerCollision(collision);
            Destroy(landmine);
            Instantiate(explosion, manager.transform);
        }
    }   
}
