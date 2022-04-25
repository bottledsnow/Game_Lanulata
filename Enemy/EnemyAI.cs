using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Bottlesnow.Utils;

public class EnemyAI : MonoBehaviour
{
    private bool EnemyAwake;
    #region 結構定義
    [System.Serializable]
    private struct sRoaming
    {
        public float reachTime;
        public float roamingDistance;
        public float roamingStopTime;
        public float roamingSpeed;
    }
    [System.Serializable]
    private struct sAlert
    {
        public float alertSpeed;
        public float alertRange;
    }
    [System.Serializable]
    private struct sTargetLose
    {
        public float loseTargerRange;
    }
    [System.Serializable]
    private struct sSimple
    {
        public float simpleMoveSpeed;
    }
    #endregion
    #region enum定義
    private enum _enemyAI
    {
        Roaming,Alert,TargetLose
    }
    #endregion

    private _enemyAI enemyAI;
    [SerializeField]
    private sRoaming Roaming;
    [SerializeField]
    private sAlert Alert;
    [SerializeField]
    private sTargetLose TargetLose;

    private Rigidbody2D EnemyRigidbody;
    private void Start()
    {
        EnemyRigidbody = GetComponent<Rigidbody2D>();

        enemyLifeLimitTime = GetComponent<EnemyLifeLimitTime>();
        LinkEnemyLifeLimitTime();
    }
    #region 如果有時間限制則把它啟動。
    private EnemyLifeLimitTime enemyLifeLimitTime;
    private void LinkEnemyLifeLimitTime()
    {
        if(enemyLifeLimitTime!=null)
        {
            enemyLifeLimitTime.enabled = true;
        }
    }
    #endregion

    #region 計時器
    private float timer=0;

    private void _timer()
    {
        timer += Time.deltaTime;
        enemyMode(modeType);
        if (timer>Roaming.reachTime)
        {
            timer = 0;
            getNewRoamingPosition();

        } 
    }

    #endregion
    #region Roaming漫遊
    private Vector3 roamingDirection;
    
    private void getNewRoamingPosition()
    {
        roamingDirection = UtilsClass.GetRandomDirection();
    }
    private void roamingMove()
    {
        EnemyRigidbody.velocity = new Vector2(roamingDirection.x*Roaming.roamingSpeed, roamingDirection.y*0);
    }
    #endregion
    #region Alert警戒
    private bool alertTrigger;
    private void alertSearch()
    {
        
    }
    #endregion
    #region Simple單純
    [SerializeField]
    private sSimple Simple;
    private enum SimpleDirection
    {
        left,right
    }
    [SerializeField]
    private SimpleDirection simpleDirection;

    private void simpleMove(SimpleDirection simpleDirection)
    {
        Rigidbody2D rigidbody;
        rigidbody = EnemyRigidbody;
        switch(simpleDirection)
        {
            case SimpleDirection.left:
                EnemyRigidbody.velocity = new Vector2(-1, EnemyRigidbody.velocity.y);
                break;
            case SimpleDirection.right:
                EnemyRigidbody.velocity = new Vector2(1, EnemyRigidbody.velocity.y);
                break;
        }
    }
    #endregion
    #region 選擇模式
    private enum enemyModeType { Roaming,Alert,Simple}
    [SerializeField]
    private enemyModeType modeType;
    private void enemyMode(enemyModeType enemyModeType)
    {
        switch (enemyModeType)
        {
            case enemyModeType.Roaming:
                roamingMove();
                break;
            case enemyModeType.Alert:

                break;
            case enemyModeType.Simple:
                simpleMove(simpleDirection);
                break;
        }
    }
    #endregion
    private void Update()
    {
        _timer();
    }
}


//Debug.Log(roamingDirection*Roaming.roamingSpeed);可行