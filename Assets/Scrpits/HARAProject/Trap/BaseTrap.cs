using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public abstract class BaseTrap : MonoBehaviour
{
    protected bool _trapMove;
    protected abstract void Start();
    protected abstract void Update();
    protected abstract void TrapMove();

    private void OnTriggerEnter2D(Collider2D collision)
    {
        _trapMove = true;
    }
}
