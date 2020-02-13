using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyCon : MonoBehaviour
{
    Rigidbody2D rigid2D;

    public float MoveMax = 5f;//x軸右移動
    public float MoveMin = 5f;//x軸左移動
    public float Speed = 10f;//敵の処理
    public int re = 1; //戻る
    private Vector2 DefPosV2;//最初の位置.X軸

    float f = 0f;

    // Start is called before the first frame update
    void Start()
    {
        rigid2D = gameObject.GetComponent<Rigidbody2D>();
        DefPosV2 = gameObject.transform.position;
        f = Speed;
    }

    // Update is called once per frame
    void Update()
    {
        Vector3 vec3 = gameObject.transform.position;

        if(DefPosV2.x - MoveMin > vec3.x||DefPosV2.x+MoveMax < vec3.x)
        {
            Speed = Speed * -1;
        }

        vec3.x = vec3.x - Speed * Time.deltaTime;
        gameObject.transform.position = vec3;

        //if(DefPosV2.x - MoveMin > vec3.x||DefPosV2.x+MoveMax < vec3.x)
        //{
        //    f = Speed * -1f;
        //}
        //rigid2D.AddForce(new Vector2(f, 0f));


        //if (DefPosV2.x > (DefPosV2.x + MoveMax) / 2)
        //{//右移動
        // //vec3.x = vec3.x + Speed * Time.deltaTime;
        // //rigid2D.AddForce(new Vector2(Speed*re, 0f));
        //}
        // if (DefPosV2.x<(DefPosV2.x - MoveMin) / 2)
        //{//左移動
        // //vec3.x = vec3.x - Speed * Time.deltaTime;
        //}
    }
}
