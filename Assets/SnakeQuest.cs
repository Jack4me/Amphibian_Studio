using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SnakeQuest : MonoBehaviour {
    public bool IsSnakeQuestActivated{ get; private set; } = false;
    public bool CanInteract{ get; private set; } = false;
    [SerializeField] BirdQuest _birdQuest;

    private void Start(){
        Player.InstantPlayer.OnPressButtonE += InstantPlayerOnOnPressButtonE;
    }

    private void InstantPlayerOnOnPressButtonE(object sender, EventArgs e){
        {
            if (CanInteract){
                if (IsSnakeQuestActivated && _birdQuest.IsMiror){
                    print("SnakeQuest Completed");
                }
                else if (IsSnakeQuestActivated){
                    print("DEAD FROG");
                }
                else{
                    IsSnakeQuestActivated = true;
                    print("SnakeQuest Activated");
                }
            }
        }
    }

    private void OnTriggerStay(Collider other){
        if (other.GetComponent<Player>()){
            CanInteract = true;
        }
    }

    private void OnTriggerExit(Collider other){
        if (other.GetComponent<Player>()){
            CanInteract = false;
        }
    }
}