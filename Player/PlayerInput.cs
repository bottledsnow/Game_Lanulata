using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerInput : MonoBehaviour
{
    public event Action OnShootingEvent;
    public event Action OnMonsterEventEvent;
    public void Update()
    {

        if (Input.GetMouseButtonDown(0))
        {
            Shoot();
            //+Debug.Log("PressedMouse0");
        }

        if(Input.GetKeyDown(KeyCode.T))
        {
            //Debug.Log("PressedT");
            EventTest();
        }
    }

    private void Shoot()
    {
        OnShootingEvent?.Invoke(); 
    }

    private void EventTest()
    {
        OnMonsterEventEvent?.Invoke();
    }
}
