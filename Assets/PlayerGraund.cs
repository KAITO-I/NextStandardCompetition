using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Tilemaps;

public class PlayerGraund : MonoBehaviour
{
    [SerializeField]
    GameObject _jumpStage;
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.tag == "Block")
        {
            //transform.parent.GetComponent<Player2>()._chack = true;
        }
        if (collision.tag == "Floor" && collision.name == "Object")
        {
            _jumpStage.GetComponent<TilemapCollider2D>().isTrigger = true;
        }
        //Debug.Log(collision.name);  
    }
    private void OnTriggeraExit2D(Collider2D collision)
    {
        if (collision.tag == "Block")
        {
            //transform.parent.GetComponent<Player2>()._chack = false;
        }
    }


}
