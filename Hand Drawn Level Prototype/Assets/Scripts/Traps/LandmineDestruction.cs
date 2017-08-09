using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LandmineDestruction : MonoBehaviour
{
    public GameObject manager;
    public GameObject explosion;

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.name == "SwordProjectile(Clone)")
        {
            //print("Hit");
            Instantiate(explosion, manager.transform);
            Destroy(this.gameObject);
        }
    }
}
