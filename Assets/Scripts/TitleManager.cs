using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class TitleManager : MonoBehaviour
{
    [SerializeField]
    Image backImage;

    [SerializeField]
    Image frontImage;

    [SerializeField]
    Sprite[] sprites;

    [SerializeField]
    float alphaChangeSpeed;

    int   spriteNum          = 0;
    bool  changeSprite       = false;
    Color frontImageColor    = new Color(1f, 1f, 1f);
    bool  stageSelect        = false;
    float oldInputHorizontal = 0f; 

    void Start()
    {
        this.backImage.sprite = this.sprites[0];
    }

    void Update()
    {
        #region タイトルからスライドショー
        if (!stageSelect)
        {
            var h = Input.GetAxisRaw("Horizontal");

            // フロント画像切り替え命令
            if (!Mathf.Approximately(h, 0f))
            {
                // 連続入力防止
                if (Mathf.Approximately(this.oldInputHorizontal, h)) return;

                // 既に切り替え中の場合、切り替え中の画像を強制的にBackに移動
                if (this.changeSprite) this.backImage.sprite = this.sprites[this.spriteNum];

                // 切り替え命令
                this.spriteNum += (h > 0f) ? 1 : -1;

                // 配列の範囲に注意
                if (this.spriteNum < 0)
                {
                    this.spriteNum = 0;
                    return;
                }

                // 最大値の場合はステージセレクトに移動する処理となる
                if (this.spriteNum == this.sprites.Length - 1) this.stageSelect = true;

                this.frontImageColor.a = 0f;

                this.frontImage.sprite = this.sprites[this.spriteNum];
                this.frontImage.color = this.frontImageColor;

                this.changeSprite = true;
            }

            // 1フレーム前のhを保存
            this.oldInputHorizontal = h;
        }
        #endregion

        // フロント画像切り替え
        if (this.changeSprite)
        {
            this.frontImageColor.a += Time.deltaTime * alphaChangeSpeed;

            this.frontImage.color = this.frontImageColor;

            // 切り替え完了
            if (this.frontImageColor.a >= 1f)
            {
                this.changeSprite = false;
                this.backImage.sprite = this.sprites[this.spriteNum];

                this.frontImageColor.a = 0f;
                this.frontImage.color = this.frontImageColor;

                // ステージセレクトモードならボタン操作に切り替えさせる
                if (this.stageSelect) SceneLoader.LoadScene(SceneLoader.Scenes.StageSelect);
            }
        }
    }
}
