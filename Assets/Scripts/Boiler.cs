using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Boiler : MonoBehaviour {
    public int countCorrectPotion = 5;
    [SerializeField] private BoilerColorChanger _boilerColorChanger;
    private List<BoilerQuest> correctPotionList = new List<BoilerQuest>();
    public bool _missionComplete{ get; private set; }

    public void TakeQuestObject(BoilerQuest boilerQuest){
        if (CorrectPotion(boilerQuest)){
            Debug.Log("Каменюка");
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

    bool CorrectPotion(BoilerQuest boilerQuest){
        if (boilerQuest is BoilerQuest){
            Debug.Log("Каменюка Верная");
            return true;
        }
        else{
            Debug.Log("Каменюка НЕ Верная");
            return false;
        }
    }

    void MissionComplete(){
        ChangeColor();
        _missionComplete = true;
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
}