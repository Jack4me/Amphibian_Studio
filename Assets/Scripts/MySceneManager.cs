using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class MySceneManager : MonoBehaviour {
    public string sceneToLoad = "lvl2";
    public string spawnPointName = "lvl2";
    [SerializeField] LvlChanger lvlChanger;
    
    private void OnTriggerEnter(Collider other){
        if (other.GetComponent<Player>() && lvlChanger.CanExit){
            StartCoroutine(LoadSceneAsync());
        }
    }

    private IEnumerator LoadSceneAsync(){
        AsyncOperation asyncLoad = SceneManager.LoadSceneAsync("lvl2");
        while (!asyncLoad.isDone){
            yield return null;
        }
       // FindObjectOfType<Player>().transform.position = GameObject.Find(spawnPointName).transform.position;
    }
    
}