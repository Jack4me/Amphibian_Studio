using System;
using System.Collections;
using System.Collections.Generic;
using UnityEditor.Search;
using UnityEngine;

public class QuestObjectVisual : MonoBehaviour {
   [SerializeField] private GameObject _visualQuest;
   private bool _IsShowingVisual = false;
   private void Start(){
      Player.InstantPlayer.OnShowVisual += InstantPlayerOnOnShowVisual;
   }

   private void InstantPlayerOnOnShowVisual(object sender, EventArgs e){
      
      if (Player.InstantPlayer.GetCurrentQuestObject() == this && !_IsShowingVisual){
         Show();
      }
      else if(_IsShowingVisual){
        Hide();
      }
      
   }

   public void Show(){
      _visualQuest.SetActive(true);
      _IsShowingVisual = true;
   }

   private void Hide(){
      _visualQuest.SetActive(false);
      _IsShowingVisual = false;
   }
}
