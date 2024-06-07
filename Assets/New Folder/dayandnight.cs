using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class dayandnight : MonoBehaviour
{
    [SerializeField] private Light sun;

    [SerializeField, Range(0, 24)] private float timeOfDay;

    [SerializeField] private float sunRotationSpeed;

    [Header("LightingPreset")]
    [SerializeField] private Gradient skyColer;
    [SerializeField] private Gradient equatorColor;
    [SerializeField] private Gradient sunColor;

    private void Update()
    {
        timeOfDay += Time.deltaTime * sunRotationSpeed;
        if (timeOfDay > 24)
            timeOfDay = 0;
        Updatelighting();
        UpdateSunRotation();
    }
    private void OnValidate()
    {
        Updatelighting();
        UpdateSunRotation();
    }
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    private void UpdateSunRotation()
    {
       float sunRotation = Mathf.Lerp(-90,270,timeOfDay/24);
        sun.transform.rotation = Quaternion.Euler(sunRotation, 
            sun.transform.rotation.y,
            sun.transform.rotation.z);
    }
    private void Updatelighting()
    {
        float timeFraction = timeOfDay / 24;
        RenderSettings.ambientEquatorColor = equatorColor.Evaluate(timeFraction);
        RenderSettings.ambientSkyColor = skyColer.Evaluate(timeFraction);
        sun.color = sunColor.Evaluate(timeFraction);


    }
}
