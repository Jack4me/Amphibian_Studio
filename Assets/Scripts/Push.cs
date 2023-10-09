using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Push : MonoBehaviour {
    private RaycastHit hitInfo;

    [SerializeField] private PlayerInput _input;
    private bool isPushing = false;
    RaycastHit hit;
    private PushableObject currentPushableObject;
    [SerializeField] Eatable _eatable;

    private void Update(){
        if (_eatable.IsEaten){
            if (Input.GetKey(KeyCode.E) && Player.InstantPlayer.IsHolding() == false){
                Vector3 inputVector = _input.InputVectorNormalize();
                Vector3 direction = new Vector3(inputVector.x, 0, inputVector.y);
                if (currentPushableObject != null){
                    Player.InstantPlayer.rotateSpeed = 0;
                    Debug.Log("Move Cube");
                    isPushing = true;
                    currentPushableObject.transform.Translate(direction * Time.deltaTime);
                }
            }
            
            if (Input.GetKeyUp(KeyCode.E) && isPushing){
                Debug.Log("Unpress E");
                isPushing = false;
                Player.InstantPlayer.rotateSpeed = 12;
            }
        }
        if (!_eatable.IsEaten){
            Debug.Log("Unpress E");
            isPushing = false;
            Player.InstantPlayer.rotateSpeed = 12;
        }

        // if (Input.GetKey(KeyCode.E) && Player.InstantPlayer.IsHolding() == false){
        //     Player.InstantPlayer.rotateSpeed = 0;
        //     Vector3 inputVector = _input.InputVectorNormalize();
        //     Vector3 direction = new Vector3(inputVector.x, 0, inputVector.y);
        //     if (Physics.Raycast(transform.position, Vector3.down, out hit, 0.3f)){
        //         Debug.Log(hit.transform.name + "NAME OF RAYCAST");
        //         if (Player.InstantPlayer.GetCurrentItem() != null){
        //             if (Player.InstantPlayer.GetCurrentItem().TryGetComponent(out PushableObject pushableObject)){
        //                 Debug.Log("Move Cube");
        //                 isPushing = true;
        //                 pushableObject.transform.Translate(-direction * Time.deltaTime);
        //             }
        //         }
        //     }
        // }
        // if (Input.GetKeyUp(KeyCode.E)){
        //    
        //         isPushing = false;
        //         Player.InstantPlayer.rotateSpeed = 12;
        //         Player.InstantPlayer.ClearSelectedItem();
        //     
        // }
    }

    private void OnTriggerEnter(Collider other){
        if (other.TryGetComponent(out PushableObject pushableObject)){
            Player.InstantPlayer.ClearSelectedItem();
            currentPushableObject = pushableObject;
        }
    }

    void OnTriggerExit(Collider other){
        currentPushableObject = null;
    }

    public bool IsPushing(){
        return isPushing;
    }
}