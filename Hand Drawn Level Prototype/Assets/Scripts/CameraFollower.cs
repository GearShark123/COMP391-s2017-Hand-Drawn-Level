using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraFollower : MonoBehaviour
{

    public float dampFactor = 0.15f;
    public Transform target;

    private Vector3 velocity = Vector3.zero;
    private Vector3 initialPosition;
    private new Camera camera;

    void Start()
    {
        camera = Camera.main;

        initialPosition = camera.WorldToViewportPoint(target.transform.position);
    }

    // Update is called once per frame
    void Update()
    {
        if (target)
        {
            Vector3 diff = target.position - camera.ViewportToWorldPoint(initialPosition);
            Vector3 destination = transform.position + diff;
            transform.position = Vector3.SmoothDamp(transform.position, destination, ref velocity, dampFactor);
        }

    }
}