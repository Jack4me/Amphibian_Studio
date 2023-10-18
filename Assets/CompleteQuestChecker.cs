using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CompleteQuestChecker : MonoBehaviour {
    [SerializeField] private Boiler _boiler;

    private void OnTriggerEnter(Collider other){
        if (other.GetComponent<Player>()){
            if (_boiler._missionComplete)
                questCompete = true;
        }
    }

    public bool questCompete{ get; private set; }
}