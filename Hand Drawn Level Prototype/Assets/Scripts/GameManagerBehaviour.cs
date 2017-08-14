using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class GameManagerBehaviour : MonoBehaviour {
    public bool finishGame = false;
    private int kills;
    private int deaths;
    private Canvas canvas;
    private ShowValueBehaviour[] valuesLabels;
	// Use this for initialization
	void Start () {
        canvas = GetComponentInChildren<Canvas>();
        valuesLabels = GetComponentsInChildren<ShowValueBehaviour>();
        kills = 0;
        deaths = 0;
        canvas.gameObject.SetActive(false);
    }
	
	// Update is called once per frame
	void Update () {
        if (finishGame) {
            finishGame = false;
            FinishGame();
        }
	}

    public void FinishGame() {
        //time
        int time = (int)Time.timeSinceLevelLoad;
        int seconds = (time % 3600) % 60;
        int minutes = (time%3600)/60;
        int hours = time/3600;
        valuesLabels[0].ChangeText(string.Format("{0:00}:{1:00}:{2:00}", hours, minutes, seconds));
        //kills
        valuesLabels[1].ChangeText(kills.ToString());
        //deaths
        valuesLabels[2].ChangeText(deaths.ToString());
        canvas.gameObject.SetActive(true);
    }

    public void PlayerDied() {
        deaths++;
    }

    public void TryAgain() {
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);
    }

    internal void KilledEnemy()
    {
        kills++;
    }
}
