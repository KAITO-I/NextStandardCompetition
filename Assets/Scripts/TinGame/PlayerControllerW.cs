using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerControllerW : PlayerController
{
    [SerializeField]
    private TinGameGameOver gameOver;

    protected override void Start()
    {
        base.Start();
    }

    private void Update()
    {
        var h = Input.GetAxisRaw("Horizontal");
        if (!Mathf.Approximately(h, 0f))
        {
            Move(h > 0f ? MoveDirection.Right : MoveDirection.Left);
        }

        if (Input.GetKeyDown(KeyCode.Space)) Jump();
    }

    private void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.tag.Equals("Bullet")) StartCoroutine(gameOver.GameOverCoroutine());
    }
}
