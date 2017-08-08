using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public class Health : MonoBehaviour {

    public float healthPoints; 

    private bool IsImmune { set; get; }

	// Use this for initialization
	void Start () {
        IsImmune = false;
    }

    public void DamageTaken(float damage, float timeToDie, Action onDie) {
        if (IsImmune) return;
        // print(healthPoints);
        healthPoints -= damage;
        // print(healthPoints);
        if (healthPoints<0.0)
        {
            onDie();
            Destroy(this.gameObject, timeToDie);
        }
    }
}
