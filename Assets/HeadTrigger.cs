using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HeadTrigger : MonoBehaviour {
    [SerializeField] private GameObject _ruby;
    [SerializeField] private AudioSource _rubySound;
    private void OnTriggerEnter(Collider other){
        if (other.GetComponent<Player>()){
            _rubySound.enabled = true;

          Rigidbody rubyRB =  _ruby.GetComponent<Rigidbody>();
          rubyRB.useGravity = true;
          rubyRB.isKinematic = false;
        }
    }
}
