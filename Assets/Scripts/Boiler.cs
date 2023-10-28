using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Boiler : MonoBehaviour {
   [SerializeField] private GameObject PromtUIBridWindow;
   [SerializeField] private CompleteQuestChecker _completeQuestChecker;
   [SerializeField] private AudioSource _potionSound;
 
    bool isDeathTalkingVisible = true;
    [SerializeField] private GameObject PromdDeathUI;
    public int countCorrectPotion = 5;
    [SerializeField] private BoilerColorChanger _boilerColorChanger;
    private List<BoilerQuest> correctPotionList = new List<BoilerQuest>();
    public bool _missionComplete{ get; private set; }

    public void TakeQuestObject(BoilerQuest boilerQuest){
        if (CorrectPotion(boilerQuest)){
            correctPotionList.Add(boilerQuest);
            boilerQuest.OnHide();
            Player.InstantPlayer.ChangeHold();
            if (correctPotionList.Count == countCorrectPotion){
                MissionComplete();
                correctPotionList.Clear();
            }
        }
        else{
            MissionFailed();
        }
    }

    void MissionComplete(){
        PromdDeathUI.SetActive(true);
        ChangeColor();
        _missionComplete = true;
        StartCoroutine(HideDeathTalkingAfterDelay(2f));
    }

    private IEnumerator HideDeathTalkingAfterDelay(float delayInSeconds){
        yield return new WaitForSeconds(delayInSeconds);
        PromdDeathUI.SetActive(false);
        isDeathTalkingVisible = false;
        if (_completeQuestChecker.questCompete){
            PromtUIBridWindow.SetActive(false);
        }
    }

    bool CorrectPotion(BoilerQuest boilerQuest){
        if (boilerQuest != null){
            _potionSound.enabled = false;
            _potionSound.enabled = true;
            Debug.Log("Каменюка Верная");
            return true;
        }
        else{
            Debug.Log("Каменюка НЕ Верная");
            return false;
        }
    }

    void ChangeColor(){
        _boilerColorChanger.ChangeBoilerColor();
    }

    void MissionFailed(){
        Debug.Log("Миссия провалена. Подходящий предмет не был принесен.");
    }

    private void OnTriggerEnter(Collider other){
        if (other.TryGetComponent(out BoilerQuest questItem)){
            Debug.Log("Hold Quest Item");
            TakeQuestObject(questItem);
        }
    }

    private void OnTriggerExit(Collider other){
        if (other.GetComponent<Player>()){
            
            if (_completeQuestChecker.questCompete){
                PromtUIBridWindow.SetActive(true);
                StartCoroutine(HideDeathTalkingAfterDelay(2f));
            }
        }
    }
}