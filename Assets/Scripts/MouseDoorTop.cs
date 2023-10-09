using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MouseDoorTop : MonoBehaviour {
    [SerializeField] Transform spawnPointTop;

    void OnTriggerEnter(Collider other){
        if (other.TryGetComponent(out Player player)){
            player.transform.position = spawnPointTop.position;
        }
    }
}
