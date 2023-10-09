using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
public class SceneHandlerToLvl1 : MonoBehaviour
{
    public string sceneToLoad = "lvl1";
    [SerializeField] LvlChanger lvlChanger;

    private void OnTriggerEnter(Collider other){
        if (other.GetComponent<Player>() ){
            StartCoroutine(LoadSceneAsync());
        }
    }

    private IEnumerator LoadSceneAsync(){
        AsyncOperation asyncLoad = SceneManager.LoadSceneAsync("lvl1");
        while (!asyncLoad.isDone){
            yield return null;
        }
    }
}
