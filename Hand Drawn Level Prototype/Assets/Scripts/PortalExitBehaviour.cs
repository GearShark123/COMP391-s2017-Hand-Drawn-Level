using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PortalExitBehaviour : MonoBehaviour {

    [HideInInspector]
    public float distance;
    public float speed = 10.0f;
    public float timeToDestroy = 0.7f;

    private Vector3 initialPosition;

    public GameObject Player { get; internal set; }

    // Use this for initialization
    void Start () {
        initialPosition = transform.position;
        Destroy(this.gameObject, timeToDestroy);
	}
	
	// Update is called once per frame
	void FixedUpdate () {
        if ((transform.position - initialPosition).magnitude < distance)
            transform.position += transform.right.normalized * speed * Time.deltaTime;
        else
        {
            if (Player)
            {
                Player.SetActive(true);
                Player.transform.position = transform.position + transform.right.normalized;
            }
        }
	}
}
