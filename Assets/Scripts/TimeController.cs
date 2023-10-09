using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class TimeController : MonoBehaviour {
    [SerializeField] private GameOverHandle gameOverHandle;
    private float _timer;
    [SerializeField] private float _gameTime;

    private void Update(){
        _gameTime -= Time.deltaTime;
        if (_gameTime <= 0){
            
            gameOverHandle.GameOver();
        }
    }

    public void AddTimeGameTime(float time){
        _gameTime += time;
    }
}