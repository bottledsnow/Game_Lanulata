using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MousePositionControl : MonoBehaviour
{
    [SerializeField]
    private Camera mainCamera;

    private void Start()
    {
        
    }
    private void Update()
    {
        Vector3 mouseWorldPosition = mainCamera.ScreenToWorldPoint(Input.mousePosition);
        mouseWorldPosition.z = 0f;
        transform.position = mouseWorldPosition;
        
        
    }
}
