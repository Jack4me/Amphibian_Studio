using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MouseDoorTranform : MonoBehaviour
{
    [SerializeField] Eatable _eatable;
    [SerializeField] Transform spawnPointTop;
   void OnTriggerEnter(Collider other){
        if (other.TryGetComponent(out Player player) && _eatable.IsSmall){
            player.transform.position = spawnPointTop.position;
        }
    }
}
