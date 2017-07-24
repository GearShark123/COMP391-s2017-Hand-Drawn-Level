using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GunBehaviour : MonoBehaviour {
    public GameObject projectile;

    public void Shoot() {
        Instantiate(projectile,transform.position, transform.rotation);
    }
}
