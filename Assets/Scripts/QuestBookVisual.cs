using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class QuestBookVisual : MonoBehaviour {
    [SerializeField] private GameObject _visualQuest;
    private bool _IsShowingVisual = false;
    private bool _IsPlayer = false;
    [SerializeField] private DeathTalking _deathTalking;
    private bool isDeathTalkingVisible = true;
    public bool IsCanPickUp{ get; private set; } = false; // надо false сделать что б нельзя было сразу поднимать

    private void Start(){
        Player.InstantPlayer.OnPressButtonE += InstantPlayerOnOnPressButtonE;
    }

    private void InstantPlayerOnOnPressButtonE(object sender, EventArgs e){
        if (_IsPlayer && !_IsShowingVisual){
            Show();
            IsCanPickUp = true;
        }
        else if (_IsShowingVisual){
            Hide();
        }
    }

    public void Show(){
        _visualQuest.SetActive(true);
        _IsShowingVisual = true;
        _IsPlayer = false;
    }

    private void Hide(){
        _visualQuest.SetActive(false);
        _IsShowingVisual = false;
    }

    private void OnTriggerStay(Collider other){
        if (other.GetComponent<Player>()){
            _IsPlayer = true;
        }
    }

    private void OnTriggerExit(Collider other){
        Hide();
        _IsPlayer = false;
        if (isDeathTalkingVisible && IsCanPickUp){
            _deathTalking.Show();
            StartCoroutine(HideDeathTalkingAfterDelay(2f));
        }
    }

    private IEnumerator HideDeathTalkingAfterDelay(float delayInSeconds){
        yield return new WaitForSeconds(delayInSeconds);
        _deathTalking.Hide();
        isDeathTalkingVisible = false;
    }

    private void Update(){
        Debug.Log("isDeathTalkingVisible" + isDeathTalkingVisible);
    }
}