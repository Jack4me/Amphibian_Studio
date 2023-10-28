using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class DieCelling : MonoBehaviour {
    [SerializeField] private GameOverHandle _gameOverHandle;
    private RawImage fallDeathImage;
    private void OnTriggerEnter(Collider other){
        if (other.GetComponent<Player>()){
            fallDeathImage = GetComponent<RawImage>();
            _gameOverHandle.GameOver(fallDeathImage);
        }
    }
}