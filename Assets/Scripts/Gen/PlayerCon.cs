using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerCon : MonoBehaviour
{
    //[SerializeField]
    PlayerController PC;


    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        PC = gameObject.GetComponent<PlayerController>();
        //X軸
        float X = Input.GetAxis("Horizontal");
        if(X<= -0.001)//左
        {
            PC.Move(PC.moveDir = PlayerController.MoveDirection.Left);
        }
        if (X >= 0.001)//左
        {
            PC.Move(PC.moveDir = PlayerController.MoveDirection.Right);
        }
        if (Input.GetKeyDown(KeyCode.Space))
        {
            PC.Jump();
        }

    }
}
