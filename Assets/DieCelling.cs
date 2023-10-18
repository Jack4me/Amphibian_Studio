using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DieCelling : MonoBehaviour {
    [SerializeField] private GameOverHandle _gameOverHandle;

    private void OnTriggerEnter(Collider other){
        if (other.GetComponent<Player>()){
            _gameOverHandle.GameOver();
        }
    }
}