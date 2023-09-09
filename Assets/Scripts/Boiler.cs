using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Boiler : MonoBehaviour {
    public GameObject poisonPrefab; // Префаб зелья, которое вы хотите выдавать
    public int countCorrectPotion = 5; // Количество подходящих предметов для выдачи зелья

    [SerializeField] private List<QuestItem> correctPotionList = new List<QuestItem>();

    public void TakeQuestObject(GameObject ObjectToBoiler){
        if (CorrectPotion(ObjectToBoiler.GetComponent<QuestItem>())){
            Debug.Log("Каменюка");
            QuestItem item = ObjectToBoiler.GetComponent<QuestItem>();
            correctPotionList.Add(item);
            ObjectToBoiler.TryGetComponent(out QuestItem questItem);
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
        return false;
    }

    void GivePotion(){
        GameObject potion = Instantiate(poisonPrefab, transform.position, Quaternion.identity);
    }

    void MissionFailed(){
        Debug.Log("Миссия провалена. Подходящий предмет не был принесен.");
    }

    private void OnTriggerEnter(Collider other){
        if (!Player.InstantPlayer.IsHolding()){
            TakeQuestObject(other.gameObject);
        }
    }
}