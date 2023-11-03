using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Eatable : MonoBehaviour {
    [SerializeField] GameObject childObject;
    [SerializeField] Collider collider;
    [SerializeField] private GameOverHandle _gameOver;
    [SerializeField] private GameObject _portalActivatedVisual;
    [SerializeField] private RawImage deathMushroomImage;

    public bool IsEaten{ get; private set; } = false;
    public bool _portalActivated{ get; private set; } = false;
    private float timeScale = 30f;

    private void Awake(){
        collider = GetComponent<Collider>();
    }

    private IEnumerator StartScale(){
        Debug.Log("Courutine");
        IsEaten = true;
        yield return new WaitForSeconds(timeScale);
        Player.InstantPlayer.transform.localScale = new Vector3(0.2f, 0.2f, 0.2f);
        IsEaten = false;
        Destroy(gameObject);
    }

    public void EatItem(){
        if (CompareTag("GrowerMushroom")){
            HideItem();
        }
        else if (CompareTag("PortalMushroom")){
            _portalActivatedVisual.SetActive(true);
            _portalActivated = true;
            HideItem();
        }
        else if (CompareTag("DeathMushroom")){
            deathMushroomImage = GetComponent<RawImage>();
            _gameOver.GameOver(deathMushroomImage);
            HideItem();
        }
        StartCoroutine(StartScale());
    }

    public void HideItem(){
        childObject.SetActive(false);
        collider.enabled = false;
    }
}