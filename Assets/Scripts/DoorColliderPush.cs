using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DoorColliderPush : MonoBehaviour
{
    public EventHandler OnPromtShow;
    private void OnCollisionEnter(Collision collision){
            Debug.Log(collision.transform.name + "Collider123");
        if (collision.transform.GetComponent<Player>()){
            
            OnPromtShow?.Invoke(this, EventArgs.Empty);
            transform.position += Vector3.right * 2f;
        }
    }
}
