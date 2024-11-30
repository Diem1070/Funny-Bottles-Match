using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Rendering.Universal;

public class Bottle : MonoBehaviour
{
    
    [Header("Bottle Properties")]
    public string personality;
    [TextArea]
    public string description;

    private Renderer bottleRender;
    public Light2D glowLight;
    
    void Start()
    {
        InitializeBottle();
        //glowLight = GetComponentInChildren<Light2D>();
        bottleRender = GetComponent<Renderer>();
        if (glowLight != null) TurnOffLight();
        else Debug.LogError("Light is null");

        if (bottleRender == null) Debug.LogError("bottle renderer is null");
    }

    void InitializeBottle()
    {
        Debug.Log("Name: " +  name);

        
    }

    public void TurnOnLight()
    {
        if (glowLight != null )
        {
            glowLight.enabled = true;       
        }
    }
    
    public void TurnOffLight()
    {
        if (glowLight != null)
        {
            glowLight.enabled = false;
        }
    }

    public void SetColor(Color color)
    {
        bottleRender.material.color = color;
    }

}
