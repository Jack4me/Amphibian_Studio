using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PickableItem : Item {
    public bool isPickedUp{ get; private set; } = false;
    QuestBookVisual _questBookVisual;

    private void Awake(){
        _questBookVisual = FindObjectOfType<QuestBookVisual>();
    }

    public void Pickup(){
        if (_questBookVisual.IsCanPickUp){
            isPickedUp = true;
            Rigidbody rb = GetComponent<Rigidbody>();
            if (rb != null){
                rb.isKinematic = true;
                Collider col = rb.gameObject.GetComponent<Collider>();
                col.isTrigger = true;
            }
            transform.parent = FindObjectOfType<PlayerInput>().interactObjectPoint;
            transform.localPosition = Vector3.zero;
        }
    }

    public void Drop(){
        if (_questBookVisual.IsCanPickUp){
            Debug.Log("Бросил");
            isPickedUp = false;
            Rigidbody rb = GetComponent<Rigidbody>();
            if (rb != null){
                rb.isKinematic = false;
                Collider col = rb.gameObject.GetComponent<Collider>();
                col.isTrigger = false;
            }
            transform.parent = null;
        }
    }
}