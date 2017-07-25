using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public class Health : MonoBehaviour {

    public float healthPoints = 1.0f;

    private bool IsImmune { set; get; }

	// Use this for initialization
	void Start () {
        IsImmune = false;
    }

    public void DamageTaken(float damage, float timeToDie, Action onDie) {
        if (IsImmune) return;

        healthPoints -= damage;
        if (healthPoints<0.0) {
            onDie();
            Destroy(this.gameObject, timeToDie);
        }
    }
}
