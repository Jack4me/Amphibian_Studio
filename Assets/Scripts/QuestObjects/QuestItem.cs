using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class QuestItem : MonoBehaviour
{
    // Start is called before the first frame update
    public void OnHide(){
        gameObject.SetActive(false);
    }
}
