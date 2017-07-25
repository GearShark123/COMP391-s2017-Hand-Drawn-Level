using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PortalSummonBehaviour : MonoBehaviour {

    public float timeToDash = .5f;
    public PortalBehaviour portal;
    public float distanceToSummon = .5f;

    private float currentTime;
    private Vector2 dashDirection = Vector2.zero;
	// Use this for initialization
	void Start () {
        currentTime = 0;
	}
	
	// Update is called once per frame
	void Update ()
    {
        currentTime += Time.deltaTime;
        if (Input.GetKeyUp(KeyCode.A))
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
        else if (Input.GetKeyUp(KeyCode.D))
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
        else if (Input.GetKeyUp(KeyCode.W))
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
        Debug.Log("Dash " + direction.ToString());

        GameObject temp = Instantiate(portal.gameObject, transform.position + (Vector3)direction*distanceToSummon, Quaternion.Euler(0, 0, Mathf.Rad2Deg * Mathf.Atan2(direction.y, direction.x)+90));
        temp.GetComponent<PortalBehaviour>().direction = direction;
    }
}
