using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ExplosionBehaviour : MonoBehaviour {

	// Use this for initialization
	void Start ()
    {
        Destroy(this.gameObject, 1.2f);
	}
	
	
}
