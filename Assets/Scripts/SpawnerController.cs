using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using System;
using System.Linq;

public class SpawnerController : MonoBehaviour {
    List<Spawner> spawners;
    private Spawner savedSpawner;
    [SerializeField] private GameObject Player;

    void Awake(){
        spawners = GetComponentsInChildren<Spawner>().ToList();
        foreach (var spawner in spawners){
            spawner.Activated += OnSpawnerActivated;
        }
        var sceneID = SceneManager.GetActiveScene().buildIndex;
        if (PlayerPrefs.HasKey($"spawner{sceneID}")){
            int savedSpawnerID = PlayerPrefs.GetInt($"spawner{sceneID}");
            foreach (var spawner in spawners){
                if (spawner.SpawnerID == savedSpawnerID){
                    savedSpawner = spawner;
                    break;
                }
            }
            Player.transform.position = savedSpawner.transform.position + new Vector3(0, 0, 0);
        }
        else{
            Player.transform.position = spawners[0].transform.position;
        }
    }

    void OnSpawnerActivated(int spawnerID){
        var sceneID = SceneManager.GetActiveScene().buildIndex;
        PlayerPrefs.SetInt($"spawner{sceneID}", spawnerID);
        Debug.Log("sceneID" + sceneID + "SpawnerID" + spawnerID);
    }

    void OnDestroy(){
        foreach (var spawner in spawners) spawner.Activated -= OnSpawnerActivated;
    }
}