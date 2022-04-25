using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PressurePlate : MonoBehaviour
{
    [SerializeField]
    private Sprite switchOn;
    [SerializeField]
    private bool trigger;
    [SerializeField]
    private EnemyEventMannager EnemyMannager;


    private void Start()
    {
        GameObject Mannager;
        Mannager = GameObject.Find("Mannager");
        EnemyMannager = Mannager.GetComponent<EnemyEventMannager>();
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if(collision.gameObject.tag=="Player")
        {
            plateTrigger();
        }
    }

    private void plateTrigger()
    {
        SpriteRenderer spriteRenderer;
        GameObject ParentGameObject;
        ParentGameObject = this.gameObject.transform.parent.gameObject;
        spriteRenderer = ParentGameObject.GetComponent<SpriteRenderer>();
        if(trigger==false)
        {
           TriggerMode();

            spriteRenderer.sprite = switchOn;
            Vector3 parentScale;
            Vector3 parentPosition;
            parentScale = ParentGameObject.transform.localScale;
            parentPosition = ParentGameObject.transform.position;
            ParentGameObject.transform.localScale = new Vector3(parentScale.x, parentScale.y * 0.5f, parentScale.z);
            //ParentGameObject.transform.position = new Vector3(parentPosition.x, parentPosition.y - parentPosition.y * 0.5f, parentPosition.z);
            trigger = true;
        }
    }
    #region EventMode 事件模式
    [System.Serializable]
    private struct enemys
    {
        public int enemyID;
        public triggermode _trigermode;
    } 
    [SerializeField]
    private enemys _enemys;
    private enum triggermode { 怪物事件}
    [SerializeField]
    
    private void TriggerMode()
    {
        switch(_enemys._trigermode)
        {
            default:
            case triggermode.怪物事件:
                EnemyMannager.enemyAwake(_enemys.enemyID);
                Debug.Log("怪物釋放");
                break;

        }
    }

#endregion
}