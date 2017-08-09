using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DroneBehaviour : MonoBehaviour {

    public float timeToAimTarget = 1.0f;
    public float timeToShoot = 1.0f;

    private float t;
    private Transform joint;
    private GunBehaviour gun;
    private float currentTimeToShoot;
    private Vector3 direction = Vector3.right;
    private bool isPlayerInArea;

    // Use this for initialization
    void Start () {
        t = 0.0f;
        joint = transform.Find("Joint");
        gun = transform.GetComponentInChildren<GunBehaviour>();
        currentTimeToShoot = 0.0f;
        isPlayerInArea = false;

    }
    public void Update()
    {
        t += Time.deltaTime;
        if (isPlayerInArea)
            currentTimeToShoot += Time.deltaTime;
        float b = Mathf.Rad2Deg * Mathf.Atan2(direction.y, direction.x);
        float a = Mathf.Rad2Deg * Mathf.Atan2(joint.right.y, joint.right.x);
        /*if (b < 0)
            b += 360;
        if (a < 0)
            a += 360;*/
        float zRotation = Mathf.LerpAngle(a, b, Mathf.Clamp(t, 0.0f, timeToAimTarget) / timeToAimTarget);

        joint.localRotation = Quaternion.Euler(0, 0, zRotation);
        if (isPlayerInArea && timeToShoot < currentTimeToShoot)
        {
            gun.Shoot();
            currentTimeToShoot = 0.0f;
            isPlayerInArea = false;
        }
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.CompareTag("Player"))
        {
            t = 0.0f;
            currentTimeToShoot = 0.0f;
            isPlayerInArea = true;
        }
    }
    private void OnTriggerExit2D(Collider2D collision)
    {
        if (collision.CompareTag("Player"))
        {
            t = 0.0f;
            currentTimeToShoot = 0.0f;
            isPlayerInArea = false;
        }
    }

    private void OnTriggerStay2D(Collider2D collision)
    {
        if (collision.CompareTag("Player"))
        {
            direction = collision.transform.position - joint.position;
            isPlayerInArea = true;
            Debug.DrawRay(joint.position, direction,Color.white);
        }
    }
}
