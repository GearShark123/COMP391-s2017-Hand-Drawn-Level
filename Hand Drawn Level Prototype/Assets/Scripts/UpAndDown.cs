using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class UpAndDown : MonoBehaviour {

    public float delta = 8.0f;  // Amount to move left and right from the start point
    public float speed = 4.0f;
    private Vector3 startPos;

    void Start()
    {
        startPos = transform.position;
    }

    void Update()
    {
        Vector3 v = startPos;
        v.y += delta * Mathf.Cos(Time.time * speed);
        transform.position = v;
    }
}
