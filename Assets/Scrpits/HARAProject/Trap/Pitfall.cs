using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Pitfall : BaseTrap
{
    [SerializeField]
    float speed;
    float _fallTime;
    Vector3 _defaltPos;
    protected override void Start()
    {
        _defaltPos = transform.position;
    }
    protected override void Update()
    {
        if (_trapMove)
        {
            TrapMove();
        }
    }
    protected override void TrapMove()
    {
        gameObject.transform.position += new Vector3(0, speed, 0);
        _fallTime += Time.deltaTime;
        if (_fallTime >= 3f)
        {
            transform.position = _defaltPos;
        }
    }
}
