using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

public class GameOverHandle : MonoBehaviour {
    [SerializeField] private GameObject gameOverVisual;
    [SerializeField] private GameObject startPosition;
    [SerializeField] private TimeController time;
    public bool gameOver{ get; private set; } = false;


    private void Update(){
        if (gameOver){
            if (Input.anyKeyDown){
                StartAgain();
                gameOver = false;
            }
        }
    }

    public void GameOver(){
        Time.timeScale = 0;
        gameOver = true;
        gameOverVisual.SetActive(true);
        Debug.Log("Game Over");
    }

    private void StartAgain(){
        gameOverVisual.SetActive(false);
        time.AddTimeGameTime(180);
        Player.InstantPlayer.transform.position = startPosition.transform.position;
        Time.timeScale = 1;
    }
}