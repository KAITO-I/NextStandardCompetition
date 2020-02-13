using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class TinGameGameOver : MonoBehaviour
{
    [SerializeField]
    Text text;

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.tag.Equals("Player")) StartCoroutine(GameOverCoroutine());
    }

    public IEnumerator GameOverCoroutine()
    {
        text.text = "GAME OVER";
        yield return new WaitForSeconds(3f);
        GameOverManager.Active();
    }
}
