using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WindowEscape : MonoBehaviour {
    [SerializeField] private CompleteQuestChecker _completeQuestChecker;
    [SerializeField] private GameObject EscapeImage;

    private void Awake(){
        EscapeImage.SetActive(false);
    }

    private void OnTriggerEnter(Collider other){
        if (other.GetComponent<Player>()){
            if (_completeQuestChecker.questCompete){
                EscapeImage.SetActive(true);
                Time.timeScale = 0;
            }
        }
    }
}