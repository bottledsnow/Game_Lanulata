using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TeachTimer : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        
    }
    private float timer;
    private float bulletCooldown=2;
    // Update is called once per frame
    void Update()
    {
        timer += Time.deltaTime;
        if (timer > bulletCooldown)
        {
            timer = 0; //���m�p�ɾ�
            Debug.Log("�ɶ����m");
        }
        Debug.Log(timer);
    }
}
