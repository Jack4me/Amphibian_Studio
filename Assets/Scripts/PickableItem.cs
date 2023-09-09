using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PickableItem : Item {
    private bool isPickedUp = false;

    // public void PickDropSystem(){
    //     if (isPickedUp){
    //         Drop();
    //         Player.InstantPlayer.ClearSelectedItem();
    //     }
    //     else{
    //         Pickup();
    //     }
    // }

    public void Pickup(){
        isPickedUp = true;
        Rigidbody rb = GetComponent<Rigidbody>();
        if (rb != null){
            rb.isKinematic = true;
        }
        transform.parent = FindObjectOfType<PlayerInput>().interactObjectPoint;
        transform.localPosition = Vector3.zero;
    }

    public void Drop(){
        Debug.Log("Бросил");
        isPickedUp = false;
        Rigidbody rb = GetComponent<Rigidbody>();
        if (rb != null){
            rb.isKinematic = false;
        }
        transform.parent = null;
    }
}