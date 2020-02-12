using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Tilemaps;

public class Player2 : PlayerController
{
    [SerializeField]
    Transform _defalt;
    bool _chack = false;
    Tilemap _block;
    TileBase _void;
    public bool _exChack;

    protected override void Start()
    {
        _exChack = false;
        base.Start();
    }
    // Update is called once per frame
    void Update()
    {
        //移動
        Move(MoveDirection.Right);
        if (!_chack)//ブロックに当たっていないとき
        {
            //初期位置と距離が離れているときはその分速度を早くする
            float addspeed = (MoveSpeed * 1 * Time.deltaTime) + (Vector3.Distance(gameObject.transform.position, _defalt.position));

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
        }
    }
    private void ExSkill()
    {
        //x軸30マス分のブロックを透明なものに塗り替える
        var screenToWorldPointPosition = gameObject.transform.position;
        Vector3Int vlickPosition = _block.WorldToCell(screenToWorldPointPosition);//タイルのポジション
        vlickPosition.x += 30;
        vlickPosition.y += 5;//ここは仮置き
        _block.SetTile(vlickPosition, _void);
        //敵が存在していた場合は消滅（この部分は敵に処理を記載）
        _exChack = true;

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
