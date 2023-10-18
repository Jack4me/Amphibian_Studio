using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SnakeQuest : MonoBehaviour {
    [SerializeField] private GameObject _toothPrefab;
    [SerializeField] private Transform createPoint;
    [SerializeField] private GameObject SnakeUIDialog;
    public bool IsSnakeQuestActivated{ get; private set; } = false;
    public bool CanInteract{ get; private set; } = false;
    [SerializeField] BirdClock birdClock;
    [SerializeField] private GameOverHandle _gameOverHandle;
    private void Start(){
        Player.InstantPlayer.OnPressButtonE += InstantPlayerOnOnPressButtonE;
    }

    private void InstantPlayerOnOnPressButtonE(object sender, EventArgs e){
        {
            if (CanInteract){
                if (IsSnakeQuestActivated && birdClock.IsMirorGave){
                    GameObject tooth = Instantiate(_toothPrefab);
                    tooth.transform.position = createPoint.position;
                    print("SnakeQuest Completed");
                    Player.InstantPlayer.OnPressButtonE -= InstantPlayerOnOnPressButtonE;
                }
                else if (IsSnakeQuestActivated){
                    print("DEAD FROG");
                    _gameOverHandle.GameOver();
                }
                else{
                    IsSnakeQuestActivated = true;
                    print("SnakeQuest Activated");
                    SnakeUIDialog.SetActive(true);
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
            SnakeUIDialog.SetActive(false);
        }
    }
}