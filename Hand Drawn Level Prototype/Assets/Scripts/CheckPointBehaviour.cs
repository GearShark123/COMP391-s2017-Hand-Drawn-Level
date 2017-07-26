using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CheckPointBehaviour : MonoBehaviour {

    // Use this for initialization
    private void Spawn(GameObject gameObject) {
        gameObject.transform.position = transform.position;
        gameObject.SetActive(true);
    }

    private void OnDrawGizmos()
    {
        Gizmos.DrawWireCube(transform.position, transform.localScale);
    }
}
