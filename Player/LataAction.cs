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
            //�p�G���a���b�a�O�W�A�åB���U����C
        }
        if (Isground==false && jumpKeyBack && LataRigidbody.velocity.y>0)
        {
            LataRigidbody.velocity = new Vector2(speedX, speedY*0.6f);
            //Debug.Log("�P�}�ť���");
            //�p�G���a�P�}�ť���C
        }
    }
    [Header("�P���a�O���Z��")]
    [Range(0, 0.5f)]
    public float distance;

    [Header("�����a�O����g�u�_�I")]
    public Transform GroundCheck;

    [Header("�a���ϼh")]
    public LayerMask GroundLayer;
    public bool grounded;
    //�b���a�����g�@�ӫܵu���g�u�A�p�G�g�u������a�O�ϼh���ܡA�N����ۦa�O


    bool Isground
    {
        get
        {
            Vector2 start = GroundCheck.position;
            Vector2 end = new Vector2(start.x, start.y - distance);
            Debug.DrawLine(start, end, Color.blue);

            grounded = Physics2D.Linecast(start, end, GroundLayer);
            //�u���b�B�@���{��

            return grounded;
        }
    }

}
