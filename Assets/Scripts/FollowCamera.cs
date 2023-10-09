using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FollowCamera : MonoBehaviour {
    public Transform target;
    
    private void Update(){
        transform.position = new Vector3(target.position.x, target.position.y + 1, target.position.z - 3);
    }
}
