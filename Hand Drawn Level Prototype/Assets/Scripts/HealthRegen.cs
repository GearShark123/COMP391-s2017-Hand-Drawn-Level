using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HealthRegen : MonoBehaviour {

    public float timeAdded;
    private float time;
    public float timeLimit;
    public float healthRegenNum = 1;

    private GameObject player;

    void Start()
    {
        player = GameObject.FindGameObjectWithTag("Player");
    }

    void Update ()
    {
        time += timeAdded;

        if (time >= timeLimit)
        {
            if (player)
            {
                Health health = player.GetComponent<Health>();
                if (!health.IsFull())
                {
                    health.HealthRegen(healthRegenNum);
                }
                Destroy(this.gameObject);
                time = 0.0f;
            }
        }
	}
}
