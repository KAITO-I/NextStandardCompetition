using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Tilemaps;

public class Salamander : BaseEnemy
{
    [SerializeField]
    int _xRange;
    Tilemap _tileMap,_trapMap;
    protected override void Start()
    {
        base.Start();
        _trapMap = GameObject.FindWithTag("Trap").GetComponent<Tilemap>();
        _tileMap = GameObject.FindWithTag("Floor").GetComponent<Tilemap>();
        _action = false;
    }
    protected override void Update()
    {
        if (_action)
        {
            DownTrap();
        }
        base.Update();  //必殺技の処理

    }

    private void DownTrap()
    {
        var screenToWorldPointPosition = gameObject.transform.position;
        Vector3Int vlickPosition = _trapMap.WorldToCell(screenToWorldPointPosition);//タイルのポジション
        vlickPosition.y -= 1;
        vlickPosition.x += Random.Range(-_xRange - 1, -1);

        if (_tileMap.GetSprite(vlickPosition) != null)
        {
            _tileMap.SetTile(vlickPosition, null);
        }
        _trapMap.SetTile(vlickPosition, _blockTile);
        _trapMap.SetColliderType(vlickPosition, Tile.ColliderType.Grid);
        flag = 1;
        _action= false;
    }
}
