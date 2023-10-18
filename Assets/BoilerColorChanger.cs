using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BoilerColorChanger : MonoBehaviour {
    public Color hdrColor = new Color(1.0f, 0.0f, 0.0f, 1.0f); // Новый цвет HDR
    public float hdrIntensity = 5.0f;
    [SerializeField] private ParticleSystem bubles;
    

    public void ChangeBoilerColor(){
        var mainpart = bubles.main;
        mainpart.startColor = Color.red;
        // Получите доступ к компоненту Material
        Renderer renderer = GetComponent<Renderer>();
        Material material = renderer.material;

        // Установите новый цвет HDR
        material.SetColor("_EmissionColor", hdrColor * hdrIntensity);
    }
}