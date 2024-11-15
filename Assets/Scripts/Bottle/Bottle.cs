using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Bottle : MonoBehaviour
{
 /*   
    [Header("Bottle Properties")]
    [SerializeField] private string name;
    [TextArea]
    [SerializeField] private string description;

    public string Name
    {
        get
        {
            return name;
        }
    }

    public string Description
    {
        get { return description; }
    }
    */
    
    [Header("Bottle Properties")]
    public string personality;
    [TextArea]
    public string description;
    
    void Start()
    {
        InitializeBottle();
    }

    void InitializeBottle()
    {
        Debug.Log("Name: " +  name);
    }
    

}
