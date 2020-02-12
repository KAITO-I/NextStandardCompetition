using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Pitfall : BaseTrap
{
    [SerializeField]
    float speed;
    protected override void Start()
    {
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
    }
}
