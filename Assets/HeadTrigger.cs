using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HeadTrigger : MonoBehaviour {
    [SerializeField] private GameObject _Ruby;
    private void OnTriggerEnter(Collider other){
        if (other.GetComponent<Player>()){
          Rigidbody rubyRB =  _Ruby.GetComponent<Rigidbody>();
          rubyRB.useGravity = true;
          rubyRB.isKinematic = false;
        }
    }
}
