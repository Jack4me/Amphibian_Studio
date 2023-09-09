using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BirdQuest : MonoBehaviour {
   [SerializeField] private Ring ringObject;

   private void OnTriggerEnter(Collider other){
      if (other.gameObject.TryGetComponent(out Ring tooth)){
         if (tooth == ringObject){
            Debug.Log("Зуб найдён");
            FindObjectOfType<GameManager>().AddTimeGameTime(180f);
            ringObject.gameObject.SetActive(false);
         }
         
      }
   }
}
