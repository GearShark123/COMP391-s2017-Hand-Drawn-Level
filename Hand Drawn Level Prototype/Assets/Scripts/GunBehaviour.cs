using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GunBehaviour : MonoBehaviour {
    public GameObject projectile;
    private Transform spwanProjectilePosition;
    private Transform joint;
    private void Start()
    {
        spwanProjectilePosition = transform.FindChild("SpawnProjectile");
        joint = transform.parent;
    }

    public void Shoot() {
        Instantiate(projectile, spwanProjectilePosition.position, joint.rotation);
    }
}
