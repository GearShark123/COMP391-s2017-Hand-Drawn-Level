using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ShowValueBehaviour : MonoBehaviour {

    public string preText;

    private Text text;

	// Use this for initialization
	void Start () {
	}

    public void ChangeText(string value) {
        if (text==null)
            text = GetComponent<Text>();
        text.text = preText + value;
    }
}
