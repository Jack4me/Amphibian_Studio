using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DeathTalking : MonoBehaviour {
    [SerializeField] GameObject _deathDialog;
    public event EventHandler deathDialog;
    
    public void Show(){
        gameObject.SetActive(true);
        
    }
    public void Hide(){
        gameObject.SetActive(false);
        
    }
}