using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Tilemaps;

public class Player2 : PlayerController
{
    [SerializeField]
    Transform _defalt;
    [SerializeField]
    Sprite _blockTile;
    //[SerializeField]
    //GameObject _jumpStage;
    public bool _chack = false;
    Tilemap _block;
    HaraManager _manager;
    Animator anim;
    bool _gole;

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
        if (_gole) return;
        if (!_manager._start) return;

        ////移動
        //Move(MoveDirection.Right);
        //初期位置と距離が離れているときはその分速度を早くする
        float addspeed = _defalt.position.x - transform.position.x;
        Move(MoveDirection.Right, addspeed);
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
        if (collision.tag == "Clear")
        {
            _gole = true;
        }
            //if (collision.tag == "Block")
            //{
            //    _chack = true;
            //}
            //if (collision.tag == "Floor"&&collision.name=="Block")
            //{
            //_jumpStage.GetComponent<TilemapCollider2D>().isTrigger = true;
            //}
        }
        //private void OnTriggeraExit2D(Collider2D collision)
        //{
        //    if (collision.tag == "Block")
        //    {
        //        _chack = false;
        //    }
        //}

    }
