using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Vector2Angle : MonoBehaviour
{
    [SerializeField]
    private  GameObject referObject;

    [SerializeField]
    private Vector2 fromVector;
    [SerializeField]
    private Vector2 toVector;

    [SerializeField]
    private Vector2 referPosition;
    [SerializeField]
    private Vector2 ThisPosition;
    [SerializeField]
    private Vector2 cursorPosition;

    [SerializeField]
    private float angle;

    private float point_X;
    private float point_Y;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        referPosition = referObject.transform.position;
        fromVector = referPosition;
        cursorPosition = Input.mousePosition;
        ThisPosition = this.transform.position;

        point_X = cursorPosition.x - ThisPosition.x;
        point_Y = cursorPosition.y - ThisPosition.y;
        toVector = new Vector2(point_X, point_Y);

        Vector2.Angle(fromVector, toVector);
        
        
    }
}
 