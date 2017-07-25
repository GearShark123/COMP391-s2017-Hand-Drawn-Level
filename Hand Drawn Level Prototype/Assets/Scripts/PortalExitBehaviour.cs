using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PortalExitBehaviour : MonoBehaviour {

    public float distance;
    public float speed = 10.0f;
    public Vector3 direction;
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
            transform.position += direction * speed * Time.deltaTime;
        else
        {
            if (Player)
            {
                Player.SetActive(true);
                Player.transform.position = transform.position + direction;
            }
        }
	}
}
