using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CoseGenBGMPlayer : MonoBehaviour
{
    [SerializeField]
    AudioClip clip;

    private void Start()
    {
        SoundManager.PlayBGM(clip);
    }
}
