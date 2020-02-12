using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TestPlayer : PlayerController
{
    [SerializeField]
    Transform _defalt;
    //void Start()
    //{
        
    //}
    void Update()
    {
        //壁から抜けた場合の距離計算
        Vector3 vec = new Vector3();
        //float addspeed = speed + Vector3.Distance(gameObject.transform.position, _defalt.position);
        //必殺
        //移動
        Move(MoveDirection.Right);
        //ジャンプ
        if(Input.GetKeyDown(KeyCode.Space)) Jump();
    }

    private void OnTriggerStay2D(Collider2D collision)
    {
        if (collision.tag == "Enemy")
        {
            //攻撃アニメーションを再生

        }
    }
}