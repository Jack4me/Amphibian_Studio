using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;
using UnityEngine.UI;

public class GameOverHandle : MonoBehaviour {

    [SerializeField] private AudioSource _kvaSound;
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

    public void GameOver(RawImage deathImage){
        if (Player.InstantPlayer.GetCurrentItem()){
            
            if (TryGetComponent(out PickableItem _pickableItem))
                _pickableItem.Drop();
        }
        _kvaSound.enabled = false;
        _kvaSound.enabled = enabled;
        Time.timeScale = 0;
        gameOver = true;
        RawImage rawImage = gameOverVisual.GetComponent<RawImage>();
        rawImage.texture = deathImage.texture;
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