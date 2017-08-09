using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GunBehaviour : MonoBehaviour {
    public GameObject projectile;
    private Transform spwanProjectilePosition;
    private Transform joint;
    private bool isAiming = false;
    private Transform portal;

    private void Start()
    {
        spwanProjectilePosition = transform.Find("SpawnProjectile");
        portal = spwanProjectilePosition.Find("Portal");
        portal.gameObject.SetActive(isAiming);
        joint = transform.parent;
    }

    public void Aim(bool isAiming) {
        portal.gameObject.SetActive(this.isAiming=isAiming);
    }

    public void Shoot() {
        Instantiate(projectile, spwanProjectilePosition.position, joint.rotation);
    }
}
