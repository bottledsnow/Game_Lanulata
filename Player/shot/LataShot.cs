using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LataShot : MonoBehaviour
{
    private void Start()
    {
        PlayerInput _PlayerInput = GetComponent<PlayerInput>();
        _PlayerInput.OnShootingEvent += _PlayerInput_OnShootingEvent;
        stateMannager = GetComponent<StateMannager>();
    }

    [SerializeField]
    private float nextFire;
    [SerializeField]
    private float fireRate = 2.0f;
    [SerializeField]
    private GameObject Bullet;
    [SerializeField]
    private float bulletSpeed;

    private StateMannager stateMannager;
    private void _PlayerInput_OnShootingEvent()
    {
        
        shot();
    }


    private void shot()
    {
        if (nextFire > fireRate)
        {
            Vector3 mousePosition = Camera.main.ScreenToWorldPoint(Input.mousePosition);
            mousePosition.z = 0f;

            //子彈角度
            float fireAngle = Vector2.Angle(mousePosition - this.transform.position, Vector2.up);
            if (mousePosition.x > this.transform.position.x)
            {
                fireAngle = -fireAngle;
            }
            //計時器歸零
            nextFire = 0;
            //生成子彈/
            GameObject bullet = Instantiate(Bullet, transform.position, Quaternion.identity) as GameObject;
            //速度
            bullet.GetComponent<Rigidbody2D>().velocity = ((mousePosition - transform.position).normalized * bulletSpeed);
            //角度
            bullet.transform.eulerAngles = new Vector3(0, 0, fireAngle);
            stateMannager.Bullets.BulletCount -= 5;
        }
    }
    private void FixedUpdate()
    {
        nextFire += Time.fixedDeltaTime;
    }
}
