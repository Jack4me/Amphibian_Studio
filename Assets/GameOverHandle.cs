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
            if (Input.GetKeyDown(KeyCode.Space)){
                StartAgain();
                gameOver = false;
            }
        }
    }

    public void GameOver(){
        if (Player.InstantPlayer.GetCurrentItem()){
            if (TryGetComponent(out PickableItem _pickableItem))
                _pickableItem.Drop();
        }
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