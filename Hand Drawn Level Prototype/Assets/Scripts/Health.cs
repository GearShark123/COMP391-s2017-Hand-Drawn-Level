using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public class Health : MonoBehaviour
{

    public int healthLimit;              // 10
    public float healthPoints;
    public GameObject redScreen;
    private GameObject playerCamera;

    private bool IsImmune { set; get; }

    // Use this for initialization
    void Start()
    {        
        playerCamera = GameObject.Find("Main Camera");
        IsImmune = false;
    }

    public void DamageTaken(float damage, float timeToDie, Action onDie)
    {
        if (IsImmune) return;
        //print(healthPoints);
        healthPoints -= damage;
        for (int i = 0; i <= damage; i++)
        {
            Instantiate(redScreen, playerCamera.transform);
        }
        //Instantiate(redScreen, playerCamera.transform);
        print(healthPoints);
        if (healthPoints <= 0f)
        {
            onDie();
            Destroy(this.gameObject, timeToDie);
        }
    }
}
