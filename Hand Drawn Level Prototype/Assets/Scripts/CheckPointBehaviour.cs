using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CheckPointBehaviour : MonoBehaviour {
    public PlayerControls player;
    public bool lastCheckpoint;
    public PlayerControls currentPlayer;

    private CheckPointBehaviour[] checkpoints;
    private new CameraFollower camera;
    private GameManagerBehaviour gameManager;

    private void Start()
    {
        currentPlayer = GameObject.FindObjectOfType<PlayerControls>();
        checkpoints = GameObject.FindObjectsOfType<CheckPointBehaviour>();
        camera = GameObject.FindObjectOfType<CameraFollower>();
        gameManager = GameObject.FindObjectOfType<GameManagerBehaviour>();
    }

    private void Update()
    {
        if (currentPlayer==null && lastCheckpoint) {
            SetupNewPlayer();
        }
    }

    private void SetupNewPlayer()
    {
        Spawn();
        foreach (CheckPointBehaviour checkpoint in checkpoints)
        {
            checkpoint.currentPlayer = this.currentPlayer;
        }
        foreach (Transform redScreen in camera.transform)
        {
            redScreen.gameObject.SetActive(false);
            Destroy(redScreen.gameObject);
        }
        camera.target = currentPlayer.transform;
        if (gameManager) gameManager.PlayerDied();
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.CompareTag("Player")) {
            foreach (CheckPointBehaviour checkpoint in checkpoints) {
                checkpoint.lastCheckpoint = false;
            }
            this.lastCheckpoint = true;
        }
    }


    private void Spawn() {
        currentPlayer = Instantiate<PlayerControls>(player, transform.position, transform.rotation);
    }

    private void OnDrawGizmos()
    {
        Gizmos.DrawWireCube(transform.position, transform.localScale);
    }
}
