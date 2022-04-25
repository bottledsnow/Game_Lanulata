using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyState : MonoBehaviour
{
    [System.Serializable]
    public struct _EnemyHps
    {
        public float EnemyHP;
        public float EnemyMaxHP;
        public float RecoverHP;
    }
    [System.Serializable]
    public struct _EnemyAttack
    {
        public float EnemyWeaponAttack;
        public float EnemyCollideAttack;
    }
    [SerializeField]
    public _EnemyHps EnemyHps;
    [SerializeField]
    public _EnemyAttack EnemyAttack;

    private void Update()
    {
        enemyHealth();
    }

    private void enemyHealth()
    {
        if(EnemyHps.EnemyHP>EnemyHps.EnemyMaxHP)
        {
            EnemyHps.EnemyHP = EnemyHps.EnemyMaxHP;
        }
    }

    #region ¸I¼²
    private void OnCollisionEnter2D(Collision2D collision)
    {
        if(collision.gameObject.tag == "Bullet")
        {
            Bullet Bullet;
            Bullet = collision.gameObject.GetComponent<Bullet>();

            float takeDamage;
            takeDamage = Bullet.BulletDamage;

            EnemyHps.EnemyHP -= takeDamage;
            EnemydieCheck();
        }
    }
    #endregion
    #region Death(¦º¤`)
    private void EnemydieCheck()
    {
        if(EnemyHps.EnemyHP<=0)
        {
            Destroy(this.gameObject);
        }
    }
    #endregion
}
