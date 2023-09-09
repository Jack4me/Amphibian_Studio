using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManager : MonoBehaviour {
    private float _timer;
    [SerializeField] private float _gameTime;

   

    private void Update(){
        _gameTime -= Time.deltaTime;
        
        if (_gameTime <= 0){
            GameOver();
        }
    }

    public void GameOver(){
        Time.timeScale = 0;
    }

    public void AddTimeGameTime(float time){
        _gameTime += time;
    }
}