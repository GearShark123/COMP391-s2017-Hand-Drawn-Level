using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PortalBehaviour : MonoBehaviour {

    public PortalExitBehaviour exitPortal;
    public float distance = 4.0f;
    public float timeToDestroy = 0.7f;
    public Vector3 direction;
    private float currentTime;

    private PortalExitBehaviour currentExitPortal;

	// Use this for initialization
	void Start () {
        Destroy(gameObject, timeToDestroy);
        Invoke("CreateExit", 0.000001f);
        currentTime = 0.0f;
    }

    private void Update()
    {
        currentTime += Time.deltaTime;
    }

    private void CreateExit() {
        GameObject temp = Instantiate(exitPortal.gameObject, transform.position, Quaternion.Euler(0, 0, Mathf.Rad2Deg * Mathf.Atan2(direction.y, direction.x) + 90));
        currentExitPortal = temp.GetComponent<PortalExitBehaviour>();
        currentExitPortal.distance = distance;
        currentExitPortal.direction = direction;
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.CompareTag("Player") && currentTime < timeToDestroy) {
            currentExitPortal.Player = collision.gameObject;
            collision.gameObject.SetActive(false);
        }
    }
}
