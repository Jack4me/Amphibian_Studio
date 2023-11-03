using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class StartCage : MonoBehaviour {
   [SerializeField] private AudioSource cageDrop;
    [SerializeField] Transform doorCollider;
    [SerializeField] Transform exitCageCollider;
    private Rigidbody _rigidbodyCage;
    [SerializeField] private DeathTalking _deathTalking;
    [SerializeField] TextPromts _textPromts;
    bool showKeybordPromt = true;

    private void Awake(){
        ShowDeathPromt();
    }

    void ShowDeathPromt(){
        _deathTalking.Show();
    }

    private void OnTriggerEnter(Collider other){
        if (other.transform.GetComponent<Player>()){
            _deathTalking.Hide();
            if (showKeybordPromt){
                _textPromts.Show();
            }
            Debug.Log("Player PUSH CAGE");
            transform.position += Vector3.right * 0.01f;
        }
    }

    private void OnCollisionEnter(Collision collision){
        if (collision.transform.CompareTag("Ground")){
            cageDrop.enabled = true;
            Rigidbody rb = exitCageCollider.gameObject.AddComponent<Rigidbody>();
            _textPromts.Hide();
            showKeybordPromt = false;
        }
    }
}