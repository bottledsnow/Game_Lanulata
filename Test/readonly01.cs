using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class readonly01 : MonoBehaviour
{
    private float value = 11;
    public readonly float readvalue;

    public float Value
    {
        get { return value;  }
    }   
    private void Start()
    {
        Debug.Log(Value);
    }
}
