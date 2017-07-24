using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AimPlayerBehaviour : MonoBehaviour {

    private float t;
    private Transform joint;

	// Use this for initialization
	void Start () {
        t = 0.0f;
        joint = transform.FindChild("Joint");
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
            float currentAngle = Vector3.Angle(Vector3.left, joint.right);
            joint.Rotate(Vector3.forward, Mathf.Lerp(currentAngle, targetAngle, Mathf.Clamp(t, 0.0f, 1.0f))- currentAngle);
            Debug.DrawRay(joint.position, direction,Color.white);
        }
    }
}
