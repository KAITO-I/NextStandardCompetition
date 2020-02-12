using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SEPlayer : MonoBehaviour
{
    AudioSource audio;

    public void Init(AudioSource source)
    {
        this.audio = source;
        this.audio.playOnAwake = false;
    }

    public void Play(AudioClip clip)
    {
        this.audio.clip = clip;
        this.audio.Play();
        Invoke("EndPlay", clip.length);
    }

    private void EndPlay()
    {
        SoundManager.SEEndCallBack(this);
    }
}
