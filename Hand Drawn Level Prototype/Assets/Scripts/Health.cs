using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.Threading;


public class Health : MonoBehaviour
{
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

    void DisplayRedScreen(float damage)
    {
        if (this.gameObject.tag == "Player")
        {
            for (int i = 1; i <= damage; i++)
            {              
                    Instantiate(redScreen, playerCamera.transform);                                        
            }           
        }
    }

    public void HealthRegen(float healthRegenPoints)
    {
        healthPoints += healthRegenPoints;
    }

    public void DamageTaken(float damage, float timeToDie, Action onDie)
    {
        if (IsImmune) return;

        #region _Red Screen_
        if (healthPoints > damage)
        {
            //print(damage + " >");
            healthPoints -= damage;
            DisplayRedScreen(damage);
        }
        else if (healthPoints == damage)

        {
            //print(damage + " ==");
            healthPoints -= damage;
            DisplayRedScreen(damage);
        }
        else
        {
            //print(damage + " ?");
            healthPoints -= damage;
            damage += healthPoints;
            DisplayRedScreen(damage);
            onDie();
            Destroy(this.gameObject, timeToDie);
        }
        #endregion        
    }
}


