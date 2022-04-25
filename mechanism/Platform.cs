using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Platform : MonoBehaviour
{
    [SerializeField]
    private GameObject[] Target;
    [SerializeField]
    private float Speed;
    // Start is called before the first frame update


    // Update is called once per frame
    void Update()
    {
        PlatformMove();
    }

    private void PlatformMove()
    {
        bool goTarget01=true;

        Vector3 Target01 = Target[0].transform.position; 
        Vector3 Target02 = Target[1].transform.position;
        Vector3 platform = transform.position;
        if(goTarget01)
        {
            Vector3 direction = (Target01 - platform).normalized;
            this.transform.position += new Vector3(direction.x, direction.y, direction.z) * Speed;
        }
        else
        {
            Vector3 direction = (Target02 - platform).normalized;
            this.transform.position += new Vector3(direction.x, direction.y, direction.z) * Speed;
        }


    }
}
