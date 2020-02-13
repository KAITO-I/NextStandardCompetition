﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Tilemaps;

public class Player2 : PlayerController
{
    [SerializeField]
    Transform _defalt;
    [SerializeField]
    Sprite _blockTile;
    bool _chack = false;
    Tilemap _block;
    HaraManager _manager;
    Animator anim;

    protected override void Start()
    {
        anim = GetComponent<Animator>();
        _manager = GameObject.FindWithTag("Manager").GetComponent<HaraManager>();
        _block = GameObject.FindWithTag("Block").GetComponent<Tilemap>();
        base.Start();
    }
    // Update is called once per frame
    void Update()
    {
        ////移動
        Move(MoveDirection.Right);
        if (!_chack)//ブロックに当たっていないとき
        {
            //初期位置と距離が離れているときはその分速度を早くする
            float addspeed = (MoveSpeed * 1 * Time.deltaTime) + (Vector3.Distance(gameObject.transform.position, _defalt.position));
            //Move(MoveDirection.Right, addspeed);
            //Debug.Log(Vector3.Distance(gameObject.transform.position, _defalt.position));
        }
        //プレイヤーのいるべき位置をずらす
        var v = _defalt.position;
        v.x += MoveSpeed * 1 * Time.deltaTime;
        _defalt.position = v;
        //ジャンプ処理
        if (Input.GetKeyDown(KeyCode.Space))
            Jump();
        //必殺処理
        if (Input.GetKeyDown(KeyCode.B))
        {
            ExSkill();
            //敵が存在していた場合は消滅（この部分は敵に処理を記載）
            _manager._exChack = true;
        }
    }
    private void ExSkill()
    {
        //x軸30マス分のブロックを透明なものに塗り替える
        var screenToWorldPointPosition = gameObject.transform.position;
        Vector3Int vlickPosition = _block.WorldToCell(screenToWorldPointPosition);//タイルのポジション
        for(int i = vlickPosition.x; i < vlickPosition.x + 30; ++i)
        {
            for(int j = vlickPosition.y; j < vlickPosition.y + 8; ++j)
            {
                if (_block.GetSprite(new Vector3Int(i, j, 0))==_blockTile)
                {
                    _block.SetTile(new Vector3Int(i, j, 0), null);
                }
            }
        }

    }
    private void OnTriggerStay2D(Collider2D collision)
        {
            if (collision.tag == "Enemy")
            {
            //攻撃アニメーションを再生
                anim.SetTrigger("Attack");
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
