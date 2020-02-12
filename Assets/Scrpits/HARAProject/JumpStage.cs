using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Tilemaps;

public class JumpStage : MonoBehaviour
{
    //乗れるように
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.tag == "Player")
        {
            GetComponent<TilemapCollider2D>().isTrigger = false;
        }
    }
}
