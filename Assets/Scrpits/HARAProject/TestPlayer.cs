using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TestPlayer : MonoBehaviour
{
    [SerializeField]
    Transform _defalt;
    public float speed;
    void Start()
    {
        
    }
    void Update()
    {
        //壁から抜けた場合の距離計算
        Vector3 vec = new Vector3();
        float addspeed = speed + Vector3.Distance(gameObject.transform.position, _defalt.position);
        //必殺
        gameObject.transform.position += new Vector3(speed, 0, 0);
    }

    private void OnTriggerStay2D(Collider2D collision)
    {
        if (collision.tag == "Enemy")
        {
            //攻撃アニメーションを再生

        }
        else if (collision.tag == "Block")
        {
            speed = 0;
        }
        else
        {
            speed = 5f;
        }
    }
}