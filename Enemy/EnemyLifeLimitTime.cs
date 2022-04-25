using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyLifeLimitTime : MonoBehaviour
{
    private EnemyEventMannager EnemyMannager;
    [SerializeField]
    private float limitTime;
    [SerializeField]
    private bool startCountDown;
    // Start is called before the first frame update
    void Start()
    {
        GameObject Mannager;
        Mannager = GameObject.Find("Mannager");
        EnemyMannager = Mannager.GetComponent<EnemyEventMannager>();

        startCountDown = true;
    }
    #region ­p®É¾¹
    private float timer = 0;

    private void _timer()
    {
        timer += Time.deltaTime;
        if (timer > limitTime)
        {
            timer = 0;
            startCountDown = false;
            EnemyMannager.enemyStop(0);
        }
    }
    #endregion

    // Update is called once per frame
    void Update()
    {
        if(startCountDown)
        {
            _timer();
        }
    }
}
