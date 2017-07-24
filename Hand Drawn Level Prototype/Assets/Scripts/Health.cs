using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public class Health : MonoBehaviour {

    public float healthPoints = 1.0f;

	// Use this for initialization
	void Start () {
		
	}

    public void DamageTaken(float damage, float timeToDie, Action onDie) {
        healthPoints -= damage;
        if (healthPoints<0.0) {
            onDie();
            Destroy(this.gameObject, timeToDie);
        }
    }
}
