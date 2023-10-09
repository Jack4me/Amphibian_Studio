using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LvlChanger : MonoBehaviour {
    public ParticleSystem _particleSystem;
    private Chalk _chalk;
    public bool CanPlayAnim{get; private set;}
    public bool CanExit{get; private set;} = false;

    private void Awake(){
        _particleSystem.Stop();
    }

    private void Start(){
        Player.InstantPlayer.OnPressButtonE += InstantPlayerOnOnPressButtonE;
    }

    private void InstantPlayerOnOnPressButtonE(object sender, EventArgs e){
        if (CanPlayAnim){
            _particleSystem.Play();
            CanExit = true;
            _chalk.gameObject.SetActive(false);
        }
    }

    private void OnTriggerEnter(Collider other){
        if (other.GetComponent<Chalk>()){
            _chalk = other.GetComponent<Chalk>();
            CanPlayAnim = true;
        }
    }

    private void OnTriggerExit(Collider other){
        if (other.GetComponent<Chalk>()){
            CanPlayAnim = false;
        }
    }
}