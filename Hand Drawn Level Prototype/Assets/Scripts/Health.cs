using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;


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

    public void DamageTaken(float damage, float timeToDie, Action onDie)
    {
        if (IsImmune) return;
<<<<<<< Updated upstream
        healthPoints -= damage;
        /* verify this code it does not seem right because it will flood the screen with game objects.
        for (int i = 0; i <= damage; i++)
=======
        //print(healthPoints + "Player");

        #region _Red Screen_
        if (healthPoints > damage)
>>>>>>> Stashed changes
        {
            //print(damage + ">");
            healthPoints -= damage;
            DisplayRedScreen(damage);
        }
<<<<<<< Updated upstream
        */
        print(healthPoints);
        if (healthPoints <= 0f)
=======
        else if (healthPoints == damage)
>>>>>>> Stashed changes
        {
            //print(damage + "==");
            healthPoints -= damage;
            DisplayRedScreen(damage);
        }
        else
        {
            healthPoints -= damage;
            damage += healthPoints;
            DisplayRedScreen(damage);
            onDie();
            Destroy(this.gameObject, timeToDie);
        }
        #endregion

        //print(healthPoints + "Dmg");        
    }
}
