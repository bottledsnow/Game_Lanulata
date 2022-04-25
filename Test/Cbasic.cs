using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Cbasic : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        myclass first = new myclass(7);
        myclass second = first;
        second.value = 5;
        Debug.Log(first.value);

        int a = 7;
        int b = a;
        b = 5;
        Debug.Log(a);

    }

    public class myclass
    {
        public int value;

        public  myclass(int value)
        {
            this.value = value;
        }
    }
    // Update is called once per frame
    void Update()
    {
        
    }
}
