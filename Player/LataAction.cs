using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LataAction : MonoBehaviour
{
    public Rigidbody2D LataRigidbody;
    [SerializeField]
    private float xForce;
    [SerializeField]
    private float yForce;
    [SerializeField]
    private float maxSpeed;
    [SerializeField]
    private float speedX;
    [SerializeField]
    private float speedY;
    [SerializeField]
    private float Movement_X;

    [SerializeField]
    private bool jumpKey
    {
        get
        {
            return Input.GetKeyDown(KeyCode.Space);
        }
    }
    private bool jumpKeyBack
    {
        get
        {
            return Input.GetKeyUp(KeyCode.Space);
        }
    }


    private void Awake()
    {
        LataRigidbody = GetComponent<Rigidbody2D>();
    }
    private void Start()
    {
        PlayerInput _Playinput = GetComponent<PlayerInput>();
        Movement_X = Input.GetAxis("Horizontal");
    }


    private void Update()
    {
        Movement_X = Input.GetAxis("Horizontal");
        Control_Speed();
        MovementX();
        Tryjum();
    }

    void MovementX()
    {
            LataRigidbody.AddForce(new Vector2(xForce * Movement_X, 0));
    }

    public void Control_Speed()
    {
        speedX = LataRigidbody.velocity.x;
        speedY = LataRigidbody.velocity.y;
        float MaxMoveSpeedX = Mathf.Clamp(speedX, -maxSpeed, maxSpeed);
        LataRigidbody.velocity = new Vector2(MaxMoveSpeedX, speedY);
    }

    void Tryjum()
    {
        speedX = LataRigidbody.velocity.x;
        speedY = LataRigidbody.velocity.y;
        if (Isground && jumpKey)
        {
            LataRigidbody.AddForce(Vector2.up * yForce);
            //如果玩家站在地板上，並且按下按鍵。
        }
        if (Isground==false && jumpKeyBack && LataRigidbody.velocity.y>0)
        {
            LataRigidbody.velocity = new Vector2(speedX, speedY*0.6f);
            //Debug.Log("鬆開空白鍵");
            //如果玩家鬆開空白鍵。
        }
    }
    [Header("感應地板的距離")]
    [Range(0, 0.5f)]
    public float distance;

    [Header("偵測地板的折射線起點")]
    public Transform GroundCheck;

    [Header("地面圖層")]
    public LayerMask GroundLayer;
    public bool grounded;
    //在玩家的底射一個很短的射線，如果射線有打到地板圖層的話，代表正踩著地板


    bool Isground
    {
        get
        {
            Vector2 start = GroundCheck.position;
            Vector2 end = new Vector2(start.x, start.y - distance);
            Debug.DrawLine(start, end, Color.blue);

            grounded = Physics2D.Linecast(start, end, GroundLayer);
            //真正在運作的程式

            return grounded;
        }
    }

}
