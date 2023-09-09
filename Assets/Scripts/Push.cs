using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine;

using UnityEngine;

public class Push : MonoBehaviour
{
    public float forcePower = 10f; // Сила толчка
    private PushableObject currentObject; // Текущий объект, который игрок может толкать/тянуть

    private void Update()
    {
        // Проверяем, нажата ли клавиша E
        if (Input.GetKeyDown(KeyCode.E))
        {
            TogglePushPullObject();
        }

        // Если текущий объект существует и игрок продолжает удерживать клавишу E
        if (currentObject != null && Input.GetKey(KeyCode.E))
        {
            MoveObject();
        }
    }

    private void TogglePushPullObject()
    {
        // Если есть текущий объект, отпускаем его
        if (currentObject != null)
        {
            ReleaseObject();
        }
        else
        {
            // Попробуем найти объект, который игрок может толкать/тянуть
            currentObject = GetCurrentObject();
            if (currentObject != null)
            {
                Debug.Log("Grabbed " + currentObject.name);
            }
        }
    }
    private void ReleaseObject()
    {
        Debug.Log("Released " + currentObject.name);
        currentObject = null;
    }

    private void MoveObject()
    {
        if (currentObject != null)
        {
            Rigidbody rb = currentObject.GetComponent<Rigidbody>();

            if (rb != null)
            {
                // Определяем направление от игрока к объекту
                Vector3 playerToObject = currentObject.transform.position - transform.position;
                playerToObject.y = 0;

                // Применяем силу в направлении, определенном игроком
                Vector3 forceDir = new Vector3(Input.GetAxis("Horizontal"), 0, Input.GetAxis("Vertical")).normalized;
                rb.AddForce(forceDir * forcePower, ForceMode.Impulse);
            }
        }
    }

   

    // Метод для определения текущего объекта, который игрок может толкать/тянуть
    private PushableObject GetCurrentObject()
    {
        RaycastHit hit;

        if (Physics.Raycast(transform.position, transform.forward, out hit, Mathf.Infinity))
        {
            PushableObject pushableObject = hit.collider.GetComponent<PushableObject>();
            if (pushableObject != null)
            {
                return pushableObject;
            }
        }

        return null;
    }
}



