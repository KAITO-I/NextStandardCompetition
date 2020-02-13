using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class InstanceBulletList : MonoBehaviour
{
    [SerializeField]
    private Transform instancePos;
    [SerializeField]
    private Bullet bullet = null;
    [SerializeField]
    private int instanceCount = 0;

    private Transform instanceListParent = null; //親リスト
    private List<Bullet> enabledInstanceList = new List<Bullet>(); //使用可能リスト
    private List<Bullet> disabledInstanceList = new List<Bullet>(); //使用不可(使用中)リスト

    public int DisabledCount
    {
        get
        {
            return disabledInstanceList.Count;
        }
    }

    private void Init()
    {
        instanceListParent = gameObject.transform;
        for (int i = 0; i < instanceCount; i++)
        {
            var obj = Instantiate(bullet) as Bullet;
            enabledInstanceList.Add(obj);
            obj.transform.parent = this.transform;
            obj.EnabledInit(this);
        }
    }

    private void Start()
    {
        Init();
    }

    //生成処理
    public void Instance()
    {
        if (!(enabledInstanceList?.Count > 0)) return;
        enabledInstanceList[0].DisEnabledInit();
        float y = Random.Range(-5.0f, 5.0f);
        enabledInstanceList[0].transform.position = new Vector2(instancePos.position.x, y);
        disabledInstanceList.Add(enabledInstanceList[0]);
        enabledInstanceList.RemoveAt(0); 
    }

    //削除処理
    public void Destroy()
    {
        disabledInstanceList[0].EnabledInit(this);
        enabledInstanceList.Add(disabledInstanceList[0]);
        disabledInstanceList.RemoveAt(0);
    }
}