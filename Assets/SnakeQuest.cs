using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class SnakeQuest : MonoBehaviour {
    [SerializeField] private GameObject _toothPrefab;
    [SerializeField] private Transform createPoint;
    [SerializeField] private GameObject snakeUIDialog;
    [SerializeField] private AudioSource _snakeSound;
    [SerializeField] private RawImage _snakeDeathImage;
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
                    _snakeSound.enabled = false;
                    _snakeSound.enabled = true;
                    Player.InstantPlayer.OnPressButtonE -= InstantPlayerOnOnPressButtonE;
                }
                else if (IsSnakeQuestActivated){
                    print("DEAD FROG");
                    _snakeDeathImage = GetComponent<RawImage>();

                    _gameOverHandle.GameOver(_snakeDeathImage);
                }
                else{
                    _snakeSound.enabled = true;
                    IsSnakeQuestActivated = true;
                    print("SnakeQuest Activated");
                    snakeUIDialog.SetActive(true);
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
            snakeUIDialog.SetActive(false);
        }
    }
}