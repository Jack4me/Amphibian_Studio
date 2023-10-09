using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using System;
public class SceneHandlerToLvl2From3 : MonoBehaviour
{
    public string sceneToLoad = "lvl2";
    [SerializeField] LvlChanger lvlChanger;
    Action OnSceneLoaded;
    private void OnTriggerEnter(Collider other){
        if (other.GetComponent<Player>() ){
            StartCoroutine(LoadSceneAsync());
        }
    }

    private IEnumerator LoadSceneAsync(){
        AsyncOperation asyncLoad = SceneManager.LoadSceneAsync("lvl2");
        while (!asyncLoad.isDone){
            yield return null;
        }
    }
}
