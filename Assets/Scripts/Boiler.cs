using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Boiler : MonoBehaviour {
    public GameObject poisonPrefab; // Префаб зелья, которое вы хотите выдавать
    public int countCorrectPotion = 5; // Количество подходящих предметов для выдачи зелья

    private List<QuestItem> correctPotionList = new List<QuestItem>();

    public void TakeQuestObject(QuestItem questItem){
        if (CorrectPotion(questItem)){
            Debug.Log("Каменюка");
            correctPotionList.Add(questItem);
            questItem.OnHide();
            if (correctPotionList.Count == countCorrectPotion){
                GivePotion();
                correctPotionList.Clear();
            }
        }
        else{
            MissionFailed();
        }
    }

    bool CorrectPotion(QuestItem questItem){
        if (questItem is QuestItem){
            Debug.Log("Каменюка Верная");
            return true;
        }
        else{
            Debug.Log("Каменюка НЕ Верная");
            return false;
        }
    }

    void GivePotion(){
        GameObject potion = Instantiate(poisonPrefab, transform.position, Quaternion.identity);
    }

    void MissionFailed(){
        Debug.Log("Миссия провалена. Подходящий предмет не был принесен.");
    }

    private void OnTriggerEnter(Collider other){
        if (other.TryGetComponent(out QuestItem questItem)){
            Debug.Log("Hold Quest Item");
            TakeQuestObject(questItem);
        }
    }
}