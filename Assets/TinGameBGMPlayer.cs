using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TinGameBGMPlayer : MonoBehaviour
{
    [SerializeField]
    AudioClip bgm;

    void Start()
    {
        SoundManager.PlayBGM(bgm);
    }
}
