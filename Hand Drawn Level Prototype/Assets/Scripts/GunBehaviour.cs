using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GunBehaviour : MonoBehaviour {
    public GameObject projectile;
    private Transform spwanProjectilePosition;
    private void Start()
    {
        spwanProjectilePosition = transform.FindChild("SpawnProjectile");
    }

    public void Shoot() {
        Instantiate(projectile, spwanProjectilePosition.position, transform.rotation);
    }
}
