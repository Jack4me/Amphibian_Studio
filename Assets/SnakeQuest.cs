using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SnakeQuest : MonoBehaviour {
    public bool IsSnakeQuestActivated{ get; private set; } = false;
    [SerializeField] BirdQuest _birdQuest;

    private void OnTriggerEnter(Collider other){
        Debug.Log(_birdQuest.IsMiror);
        if (other.GetComponent<Player>()){
            if (IsSnakeQuestActivated && _birdQuest.IsMiror){
                print("SnakeQuest Completed");

            }
            else if (IsSnakeQuestActivated  ){
                print("DEAD FROG");

            }
                else
            {
                IsSnakeQuestActivated = true;
                print("SnakeQuest Activated");
            }
        }
        
    }
}