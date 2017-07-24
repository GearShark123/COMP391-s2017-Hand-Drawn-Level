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

	// Use this for initialization
	void Start () {
        t = 0.0f;
        joint = transform.FindChild("Joint");
        gun = transform.GetComponentInChildren<GunBehaviour>();
        currentTimeToShoot = 0.0f;

    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.CompareTag("Player"))
        {
            t = 0.0f;
        }
    }
    private void OnTriggerExit2D(Collider2D collision)
    {
        if (collision.CompareTag("Player"))
        {
            t = 0.0f;
        }
    }

    private void OnTriggerStay2D(Collider2D collision)
    {
        if (collision.CompareTag("Player"))
        {
            Vector3 direction = collision.transform.position - joint.position;
            float targetAngle = Vector3.Angle(Vector3.left, direction);
            t += Time.deltaTime;
            currentTimeToShoot += Time.deltaTime;
            float currentAngle = Vector3.Angle(Vector3.left, joint.right);
            joint.Rotate(Vector3.forward, Mathf.Lerp(currentAngle, targetAngle, Mathf.Clamp(t, 0.0f, timeToAimTarget)/timeToAimTarget)- currentAngle);
            if (timeToShoot < currentTimeToShoot) {
                gun.Shoot();
                currentTimeToShoot = 0.0f;
            }
            Debug.DrawRay(joint.position, direction,Color.white);
        }
    }
}
