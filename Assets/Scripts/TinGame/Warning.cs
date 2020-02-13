using System.Collections;
using UnityEngine;
using UnityEngine.UI;

public class Warning : MonoBehaviour
{
    [SerializeField]
    private float displayTime = 0;
    [SerializeField]
    private float flashSpeed = 0;
    [SerializeField]
    private Image warningImage = null;

    public bool IsStart { set; get; }

    public IEnumerator WarningAnimation()
    {
        #region 初期化
        float _timeCount = 0;
        float _alpha = 0;
        warningImage.gameObject.SetActive(true);
        #endregion

        while (_timeCount < displayTime)
        {
            _timeCount += Time.deltaTime;
            #region 点滅処理
            //alpha値の設定
            _alpha = Mathf.Sin(Time.time * flashSpeed) / 2 + 0.5f;
            //透明度の変更
            warningImage.color = new Color(1f, 1f, 1f, _alpha);
            #endregion
            yield return null;
        }

        #region 終了処理
        warningImage.gameObject.SetActive(false);
        IsStart = true;
        #endregion
    }
}　