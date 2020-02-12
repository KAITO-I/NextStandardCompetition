using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player2 : PlayerController
{
    [SerializeField]
    Transform _defalt;
    bool _chack = false;

    //void Start()
    //{

    //}
    // Update is called once per frame
    void Update()
    {
        //移動
        Move(MoveDirection.Right);
        if (!_chack)//ブロックに当たっていないとき
        {
            //初期位置と距離が離れているときはその分速度を早くする
            float addspeed = speed + Vector3.Distance(gameObject.transform.position, _defalt.position);
        }
        //プレイヤーのいるべき位置をずらす
        var v = _defalt.position;
        //v.x+=
        //_defalt.position = gameObject.transform.position;



        if (Input.GetKeyDown(KeyCode.Space))
            Jump();

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
