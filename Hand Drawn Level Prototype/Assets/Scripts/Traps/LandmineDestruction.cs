using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LandmineDestruction : MonoBehaviour
{
    public GameObject manager;
    public GameObject explosion;

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.CompareTag("Sword"))
        {
            Instantiate(explosion, manager.transform);
            Destroy(this.gameObject);
        }

    }
    
}
