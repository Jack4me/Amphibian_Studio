using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BirdQuest : MonoBehaviour {
    public bool IsMiror{ get; private set; } = false;
    [SerializeField] private SnakeQuest _snakeQuest;

    private void OnTriggerEnter(Collider other){
        if (_snakeQuest.IsSnakeQuestActivated){
            if (other.gameObject.TryGetComponent(out Miror miror)){
                Debug.Log("Miror найдён");
                IsMiror = true;
                miror.gameObject.SetActive(false);
            }
        }
    }
}