using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Tilemaps;

public class Salamander : BaseEnemy
{
    [SerializeField]
    int _xRange;
    Tilemap _tileMap,_trapMap;
    bool _downDis;
    protected override void Start()
    {
        base.Start();
        _trapMap = GameObject.FindWithTag("Trap").GetComponent<Tilemap>();
        _tileMap = GameObject.FindWithTag("Floor").GetComponent<Tilemap>();
        _downDis = true;
    }
    protected override void Update()
    {
        if (_downDis)
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
        _downDis = false;
    }
}
