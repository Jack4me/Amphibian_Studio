using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FootSteps : MonoBehaviour {
   [SerializeField] private AudioSource _audioSource;
  

   private void Update(){
      if (Player.InstantPlayer.IsWalking()){
         _audioSource.enabled = true;
      }
      else{
         _audioSource.enabled = false;

      }
   }
}
