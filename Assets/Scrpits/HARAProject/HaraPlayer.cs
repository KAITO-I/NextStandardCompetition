using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HaraPlayer : PlayerController
{
    [SerializeField]
    Transform _defalt;
    bool _chack = false;
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
        if (!_chack)//ブロックに当たっていないとき
            _defalt.position = gameObject.transform.position;
        //ジャンプ
        //if(Input.GetKeyDown(KeyCode.Space))
        //    Jump();
    }

    private void OnTriggerStay2D(Collider2D collision)
    {
        if (collision.tag == "Enemy")
        {
            //攻撃アニメーションを再生

        }
        if (collision.tag == "Block")
        {
            _chack = true;
        }
    }
    private void OnTriggeraExit2D(Collider2D collision)
    {
        if (collision.tag == "Block")
        {
            _chack = false;
        }
    }
}