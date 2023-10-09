using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Eatable : MonoBehaviour {
    [SerializeField] GameObject childObject;
    [SerializeField] Collider collider;
    public bool IsEaten{ get; private set; } = false;
    public bool IsSmall{ get; private set; } = false;
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
            Player.InstantPlayer.transform.localScale = new Vector3(0.3f, 0.3f, 0.3f);
            HideItem();
        }
        else if (CompareTag("ReduceMushroom"))
        {
            
            Player.InstantPlayer.transform.localScale = new Vector3(0.1f, 0.1f, 0.1f);
            IsSmall = true;
            HideItem();
        }
        StartCoroutine(StartScale());
    }

    public void HideItem(){
        childObject.SetActive(false);
        collider.enabled = false;
    }
}