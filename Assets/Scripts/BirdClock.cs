using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BirdClock : MonoBehaviour {
   
    [SerializeField] private GameObject _startMirorQuestUI;
    [SerializeField] private AudioSource _birdSong;
    public bool IsMirorGave{ get; private set; } = false; //сделай фолс
    
    public bool IsCarryMiror{ get; private set; } = false;
    [SerializeField] private SnakeQuest _snakeQuest;
    public bool CanInteract{ get; private set; } = false;
    private Miror _miror;
    private bool dialodStartUI = true;

    private void Awake(){
        Player.InstantPlayer.OnPressButtonE += InstantPlayerOnOnPressButtonE;
    }

    private void InstantPlayerOnOnPressButtonE(object sender, EventArgs e){
        if (CanInteract){
            if (_snakeQuest.IsSnakeQuestActivated){
                print("PRESS E");
                if (IsCarryMiror){
                    Debug.Log("Miror найдён");
                    IsMirorGave = true;
                     _miror.gameObject.SetActive(false);
                     _birdSong.enabled = true;
                    if ( Player.InstantPlayer.GetCurrentItem().TryGetComponent(out PickableItem _pickableItem)){
                        Player.InstantPlayer.ChangeHold();
                        _pickableItem.Drop();
                        Player.InstantPlayer.SetSelectedItem(null);
                        IsCarryMiror = false;
                    }
                   
                   
                    
                }
            }
        }
    }

    private void OnTriggerStay(Collider other){
        if (other.GetComponent<Player>()){
            CanInteract = true;
        }
        if (other.TryGetComponent(out Miror miror)){
            IsCarryMiror = true;
            _miror = miror;
            print("Miror is here");
        }
    }

    private void OnTriggerExit(Collider other){
        if (other.GetComponent<Player>()){
            
            CanInteract = false;
        }
    }

    private void OnTriggerEnter(Collider other){
        if (other.GetComponent<Player>()){
            if (dialodStartUI&&_snakeQuest.IsSnakeQuestActivated){
                _startMirorQuestUI.SetActive(true);
                StartCoroutine(HideUIDialog(2f));
            }
        }
    }

    public IEnumerator HideUIDialog(float delayTimer){
        yield return new WaitForSeconds(delayTimer);
        _startMirorQuestUI.SetActive(false);
        dialodStartUI = false;
    }
}