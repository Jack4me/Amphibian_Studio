using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class TimeController : MonoBehaviour {
    [SerializeField] private GameOverHandle gameOverHandle;
    private float _timer;
    [SerializeField] private float _gameTime;
   
    private RawImage _deathImage;

    private void Update(){
        _gameTime -= Time.deltaTime;
        if (_gameTime <= 0){
            _deathImage = GetComponent<RawImage>();
            gameOverHandle.GameOver(_deathImage);
        }
    }

    public void AddTimeGameTime(float time){
        _gameTime += time;
    }
}