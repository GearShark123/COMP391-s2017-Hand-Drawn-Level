using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WeaponPortalControls : MonoBehaviour {

    public GameObject weapon;

	// Update is called once per frame
	void Update () {
        if (Input.GetKey(KeyCode.Mouse1))
        {
            weapon.SetActive = true;
        }
        else
        {
            weapon.SetActive = false;
        }
    }
}
