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
    
    void Start()
    {
        InitializeBottle();
        bottleRender = GetComponent<Renderer>();

        if (bottleRender == null) Debug.LogError("bottle renderer is null");
    }

    void InitializeBottle()
    {
        Debug.Log("Name: " + name);

    }

    public void SetColor(Color color)
    {
        bottleRender.material.color = color;
    }

}
