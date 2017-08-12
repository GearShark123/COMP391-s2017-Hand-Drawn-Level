﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SwordBehaviour : MonoBehaviour {

    public float timeToDestroy = 5.0f;
    public float speed = 1.0f;
    public float damage;
    private bool hit;

    // Use this for initialization
    void Start()
    {
        Destroy(this.gameObject, timeToDestroy);
        hit = false;
    }

    // Update is called once per frame
    void Update()
    {
        if (hit == false)
        {
            Vector3 direction = transform.right.normalized;
            transform.position += direction * speed * Time.deltaTime;
        }
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        HandlePlayerCollision(collision);
    }

    //private void OnTriggerExit2D(Collider2D collision)
    //{
    //    HandlePlayerCollision(collision);
    //}

    //private void OnTriggerStay2D(Collider2D collision)
    //{
    //    HandlePlayerCollision(collision);
    //}

    private void HandlePlayerCollision(Collider2D collision)
    {
        hit = true;                
    }
}
