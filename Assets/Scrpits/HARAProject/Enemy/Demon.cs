﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine.Tilemaps;
using UnityEngine;

public class Demon : BaseEnemy
{
    [SerializeField]
    GameObject _trapObj;
    [SerializeField]
    int _xRange, _yRange;

    Tilemap _tilemap;

    protected override void Start()
    {
        base.Start();
        _tilemap = GameObject.FindWithTag("Block").GetComponent<Tilemap>();
        _action = false;
    }

    protected override void Update()
    {
        if (_action)//タイルを出現させる処理
        {
            BlockDisplay();
        }
        base.Update();//必殺技の処理
    }

    //ブロックを出現させる処理
    private void BlockDisplay()
    {
            var screenToWorldPointPosition = gameObject.transform.position;
            Vector3Int vlickPosition = _tilemap.WorldToCell(screenToWorldPointPosition);//タイルのポジション
            vlickPosition.x += Random.Range(-_xRange - 1, -1);
            vlickPosition.y += Random.Range(-_yRange, _yRange);
            Vector3 vec = _tilemap.GetCellCenterWorld(vlickPosition);
             GameObject O= Instantiate(_trapObj, gameObject.transform.position, Quaternion.identity);
            StartCoroutine(BlackMove(O,vec));
            Debug.Log(vec);
            flag = 1;
            _action= false;
    }
    private IEnumerator BlackMove(GameObject obj,Vector3 vec)
    {
        float t = 0f;
        Vector3 v = obj.transform.position;
        do
        {   
            Vector3 pos = Vector3.Lerp(v, vec, t);
            obj.transform.position = pos;
            t += 0.1f;
            yield return new WaitForFixedUpdate();
        } while (t < 1);
    }
}
