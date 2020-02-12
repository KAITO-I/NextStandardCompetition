using System.Collections;
using System.Collections.Generic;
using UnityEngine.Tilemaps;
using UnityEngine;

public abstract class BaseEnemy : MonoBehaviour
{
    [SerializeField]
    protected TileBase _blockTile;
    protected HaraManager _manager;

    bool _exChack;
    GameObject _playerObj;
    // Start is called before the first frame update
    protected virtual void Start()
    {
        _manager = GameObject.FindwithTag("Manager");
    }
    protected virtual void Update()
    {
        _exChack = _manager._exChack;
        //必殺技が発動したとき
        if (_exChack )
        {
            //範囲が３０タイル以内でプレイヤーより前にいる敵に対して
            if(_playerObj.transform.position.x + 30 >gameObject.transform.position.x && _playerObj.transform.position.x < gameObject.transform.position.x)
            {
                //Y軸判定
                if (_playerObj.transform.position.y + 5 > gameObject.transform.position.y&&_playerObj.transform.position.y<gameObject.transform.position.y)
                {
                    EnemyDead();
                }
            }
        }
    }

    protected virtual void EnemyDead()
    {
        Destroy(gameObject);
    }

    protected void OnTriggerStay2D(Collider2D collision)
    {
        if (collision.tag == "Player")
        {
            EnemyDead();
        }
    }
}
