using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class InstanceBullet : MonoBehaviour
{
    [SerializeField]
    private Warning warning;
    [SerializeField]
    private InstanceBulletList instanceBulletList;

    private const int plusInstanceNum = 2;//レベルアップで追加される最大個数

    private int level = 1;
    private int maxInstance = 5;
    private float levelUpTime = 5.0f;

    private void Start()
    {
        StartCoroutine(LevelUpCoroutine());
        StartCoroutine(InstanceBulletCoroutine());
    }

    #region レベルアップ処理
    private void LevelUp()
    {
        level++;
        maxInstance += plusInstanceNum;
        warning.IsStart = false;
    }

    IEnumerator LevelUpCoroutine()
    {
        //最初のレベルアップまでは10秒
        while (level != 2)
        {
            yield return new WaitForSeconds(10f);
            StartCoroutine(warning.WarningAnimation());
            while (true)
            {
                if (warning.IsStart)
                {
                    LevelUp();
                    break;
                }
                yield return null;
            }
        }

        //以降のレベルアップまでは5秒
        while (true)
        {
            yield return new WaitForSeconds(levelUpTime);
            StartCoroutine(warning.WarningAnimation());
            while (true)
            {
                if (warning.IsStart)
                {
                    LevelUp();
                    break;
                }
                yield return null;
            }
        }
    }
    #endregion

    #region 生成処理
    IEnumerator InstanceBulletCoroutine()
    {
        while (true)
        {
            while (true)
            {
                if (instanceBulletList.DisabledCount < maxInstance)
                {
                    break;
                }
                yield return null;
            }
            instanceBulletList.Instance();
            yield return new WaitForSeconds((float)5 / maxInstance);
        }
    }
    #endregion
}