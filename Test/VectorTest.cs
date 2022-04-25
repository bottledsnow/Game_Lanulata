using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class VectorTest : MonoBehaviour
{
    private Vector3 test;
    // Start is called before the first frame update
    void Start()
    {
        test = new Vector3(3, 4, 5);
       // test = new Vector3(test.x, test.y,test.z).normalized;
           test.Normalize();
        //幹這兩個根本沒差
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
