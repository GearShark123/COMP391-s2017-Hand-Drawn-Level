﻿using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PortalSummonBehaviour : MonoBehaviour {

    public float timeToDash = .5f;
    public PortalBehaviour portal;
    public float distanceToSummon = .5f;
    public float timeBetweenDashes = 1.0f;

    private float currentTime;
    private Vector2 dashDirection = Vector2.zero;
    private float lastTimeDash;

    // Use this for initialization
    void Start () {
        currentTime = 0;
        lastTimeDash = Time.timeSinceLevelLoad;
	}
	
	// Update is called once per frame
	void Update ()
    {
        currentTime += Time.deltaTime;
        if (Input.GetKeyDown(KeyCode.A))
        {
            if (dashDirection.Equals(Vector2.left))// is it double left?
            {
                dashDirection = Vector2.zero;
                if (currentTime < timeToDash)// is it in time for double?
                {
                    Dash(Vector2.left);
                }
            }
            else
            {
                dashDirection = Vector2.left;
            }
        }
        else if (Input.GetKeyDown(KeyCode.D))
        {
            if (dashDirection.Equals(Vector2.right))// is it double right?
            {
                dashDirection = Vector2.zero;
                if (currentTime < timeToDash)
                {// is it in time for double?
                    Dash(Vector2.right);
                }
            }
            else
            {
                dashDirection = Vector2.right;
            }
        }
        else if (Input.GetKeyDown(KeyCode.W))
        {
            if (dashDirection.Equals(Vector2.up))// is it double up?
            {
                dashDirection = Vector2.zero;
                if (currentTime < timeToDash)// is it in time for double?
                {
                    Dash(Vector2.up);
                }
            }
            else
            {
                dashDirection = Vector2.up;
            }
        }
        if (currentTime>timeToDash) {
            currentTime = 0.0f;
            dashDirection = Vector3.zero;
        }
	}

    private void Dash(Vector2 direction)
    {
        if (Time.timeSinceLevelLoad - lastTimeDash > timeBetweenDashes)
        {
            GameObject temp = Instantiate(portal.gameObject, transform.position + (Vector3)direction * distanceToSummon, Quaternion.Euler(0, 0, Mathf.Rad2Deg * Mathf.Atan2(direction.y, direction.x)));
            temp.GetComponent<PortalBehaviour>().direction = direction;
            lastTimeDash = Time.timeSinceLevelLoad;
        }
    }
}
