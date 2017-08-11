using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HealthRegen : MonoBehaviour {

    public float timeAdded;
    private float time;
    public float timeLimit;

    private GameObject player;
    private float healthLimit = 10;
    private float healthRegenNum = 1;

    void Start()
    {
        player = GameObject.FindGameObjectWithTag("Player");
    }

    void Update ()
    {
        time += timeAdded;

        if (time >= timeLimit)
        {
            Health health = player.GetComponent<Health>();
            if (health.healthPoints < healthLimit)
            {
                health.HealthRegen(healthRegenNum);
            }
            Destroy(this.gameObject);
            time = 0.0f;
        }
	}
}
