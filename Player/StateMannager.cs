using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;


public class StateMannager : MonoBehaviour
{
    [System.Serializable]
    public struct _Hps
    {
        [Range(0, 100)]
        public float HP;
        public float reHP;
    }
    [System.Serializable]
    public struct _Bullets
    {
        [Range(0, 100)]
        public float BulletCount;
        public float BulletCountRecover;
    }

    public _Hps Hps;
    public _Bullets Bullets;

    #region HP宣告
    [SerializeField]
    private GameObject IHP;
    [SerializeField]
    private GameObject IHPLose;
    private RectTransform IHPRectTran;
    private RectTransform IHPLoseRectTran;
    #endregion
    #region Bullet宣告
    [SerializeField]
    private GameObject IBulletCount;
    [SerializeField]
    private GameObject IBulletCountLose;
    private RectTransform IBulletCountRectTran;
    private RectTransform IBulletCountLoseRectTran;
    #endregion
    private void Start()
    {
        IHPRectTran = IHP.GetComponent<RectTransform>();
        IHPLoseRectTran = IHPLose.GetComponent<RectTransform>();

        IBulletCountRectTran = IBulletCount.GetComponent<RectTransform>();
        IBulletCountLoseRectTran = IBulletCountLose.GetComponent<RectTransform>();
        
        originHPPos();
        originBulletPos();
    }
    private void Update()
    {
        HPChange();
        BulletChange();
        bulletLimit();
        _timer();
        HPLimit();
    }
    #region HP Change
    private float HPposx, HPposy, HPposz;
    private void originHPPos()
    {
        HPposx = IHPLoseRectTran.anchoredPosition3D.x;
        HPposy = IHPLoseRectTran.anchoredPosition3D.y;
        HPposz = IHPLoseRectTran.anchoredPosition3D.z;
    }
    private void HPChange()
    {
        float width = 0;
        float height = 80;
        float newHPPosx;
        width = (100 - Hps.HP) * 5;
        newHPPosx = HPposx - width / 2;
        IHPLoseRectTran.sizeDelta = new Vector2(width, height);
        IHPLoseRectTran.anchoredPosition3D = new Vector3(newHPPosx, HPposy, HPposz);
    }
    #endregion
    #region BulletCount Change
    private float Bulletposx, Bulletposy, Bulletposz;
    private void originBulletPos()
    {
        Bulletposx = IBulletCountLoseRectTran.anchoredPosition3D.x;
        Bulletposy = IBulletCountLoseRectTran.anchoredPosition3D.y;
        Bulletposz = IBulletCountLoseRectTran.anchoredPosition3D.z;
    }
    private void BulletChange()
    {
        float width = 0;
        float height = 80;
        float newBulletPosx;
        width = (100 - Bullets.BulletCount) * 5;
        newBulletPosx = Bulletposx - width / 2;
        IBulletCountLoseRectTran.sizeDelta = new Vector2(width, height);
        IBulletCountLoseRectTran.anchoredPosition3D = new Vector3(newBulletPosx, Bulletposy, Bulletposz);
    }
    #endregion
    #region BulletLimit & HPLimit
    private void bulletLimit()
    {
        if(Bullets.BulletCount>100)
        {
            Bullets.BulletCount = 100;
        }
        if(Bullets.BulletCount<0)
        {
            Bullets.BulletCount = 0;
        }
        if(Bullets.BulletCount<20)
        {
            LataShot lataShot;
            lataShot = GetComponent<LataShot>();
            lataShot.enabled = false;
        }else
        {
            LataShot lataShot;
            lataShot = GetComponent<LataShot>();
            lataShot.enabled = true;
        }
    }
    public bool PlayerDeath;
    private void HPLimit()
    {
        if(Hps.HP>100)
        {
            Hps.HP = 100;
        }
        if(Hps.HP<0)
        {
            Hps.HP = 0;
            PlayerDeath = true;
            Debug.Log("玩家死亡");
            pleyerdeath();
        }
    }
    #endregion
    #region PlayerDeath
    private void pleyerdeath()
    {
        LataAction LataAction;
        LataAction = GetComponent<LataAction>();
        LataShot LataShot;
        LataShot = GetComponent<LataShot>();
        Animator LataAnimator;
        LataAnimator = GetComponent<Animator>();
        if (PlayerDeath)
        {
            LataAction.enabled = false;
            LataShot.enabled = false;
            LataAnimator.Play("PlayerDeath");
        }
    }
    public void LoadScene()
    {
        SceneManager.LoadScene(1); 
    }
    #endregion
    #region 計時器
    private float timer;
    //目前有子彈回復、...
    private void _timer()
    {
        timer += Time.deltaTime;
        if (timer > 0.1)
        {
            timer = 0;
            Bullets.BulletCount += Bullets.BulletCountRecover;
        }
    }
    #endregion
    #region 碰撞單位
    private void OnCollisionEnter2D(Collision2D collision)
    {
        //Debug.Log(collision.gameObject.tag);
        if (collision.gameObject.tag == "Enemy")
        {
            EnemyAI enemyAI;
            enemyAI = collision.gameObject.GetComponent<EnemyAI>();
            if( enemyAI.enabled)
            {
                EnemyState enemyState;
                enemyState = collision.gameObject.GetComponent<EnemyState>();
                float takeDamage;
                takeDamage = enemyState.EnemyAttack.EnemyCollideAttack;

                Hps.HP -= takeDamage;

                
                
            } else
            {
                Debug.Log("敵人尚未啟用");
            }
        }
    }
    #endregion
}