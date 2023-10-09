using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
public class SceneHandlerToLvl3 : MonoBehaviour
{
    public string sceneToLoad = "lvl3";
    [SerializeField] LvlChanger lvlChanger;

    private void OnTriggerEnter(Collider other){
        if (other.GetComponent<Player>() ){
            StartCoroutine(LoadSceneAsync());
        }
    }

    private IEnumerator LoadSceneAsync(){
        AsyncOperation asyncLoad = SceneManager.LoadSceneAsync("lvl3");
        while (!asyncLoad.isDone){
            yield return null;
        }
    }
}
