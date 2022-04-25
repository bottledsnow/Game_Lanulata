using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyEventMannager : MonoBehaviour
{
    [SerializeField]
    private PlayerInput _playerInput;
    [SerializeField]
    private GameObject[] _enemys;

    void Start()
    {
        _playerInput.OnMonsterEventEvent += _playerInput_OnMonsterEventEvent;

    }

    private void _playerInput_OnMonsterEventEvent()
    {
        
    }

    public void enemyAwake(int id)
    {
        EnemyAI ai;
        SpriteRenderer SpriteRenderer;
        Animator animator;
        ai = _enemys[id].GetComponent<EnemyAI>();
        SpriteRenderer = _enemys[id].GetComponent<SpriteRenderer>();
        animator = _enemys[id].GetComponent<Animator>();
        if(ai.enabled==false)
        {
            ai.enabled = true;
            animator.Play("EnemyBlackAwake");
            SpriteRenderer.color = Color.white;
            
        }
    }

    public void enemyStop(int id)
    {
        EnemyAI ai;
        SpriteRenderer SpriteRenderer;
        Animator animator;
        ai = _enemys[id].GetComponent<EnemyAI>();
        SpriteRenderer = _enemys[id].GetComponent<SpriteRenderer>();
        animator = _enemys[id].GetComponent<Animator>();
        if (ai.enabled == true)
        {
            ai.enabled = false;
            animator.Play("EnemyBlackStop");
            SpriteRenderer.color = Color.black;
        }
    }
    // Update is called once per frame
    void Update()
    {
        
    }
    
    
}
