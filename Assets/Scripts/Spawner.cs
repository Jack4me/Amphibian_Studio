using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;
using Random = System.Random;

class Spawner : MonoBehaviour {
    public  Action<int> Activated;

    public int SpawnerID;

    void OnValidate(){
        if (SpawnerID > 0){
            return;
        }
        Random random = new Random();
        SpawnerID = random.Next(1, 1000000000);
    }

    void OnTriggerEnter(Collider other){
        Debug.Log("Trigger" + other.transform.name);
        Activated?.Invoke(SpawnerID);
    }
}