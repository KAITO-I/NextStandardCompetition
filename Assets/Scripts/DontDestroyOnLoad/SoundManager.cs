using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SoundManager : MonoBehaviour
{
    private static SoundManager instance;

    public static void PlayBGM(AudioClip bgm) {
        instance.PlayBackGroundMusic(bgm);
    }

    public static void StopBGM() {
        instance.StopBackGroundMusic();
    }

    public static void PlaySE(AudioClip se) {
        instance.PlaySoundEffect(se);
    }

    public static void SEEndCallBack(SEPlayer se) {
        instance.EndPlaySE(se);
    }

    //==============================
    // クラス
    //==============================
    // BGM
    AudioSource bgm;

    // SE
    [SerializeField]
    int canPlaySECount;
    List<SEPlayer> usedSEGameObject   = new List<SEPlayer>();
    List<SEPlayer> unusedSEGameObject = new List<SEPlayer>();

    //------------------------------
    // Startより前に初期化
    //------------------------------
    void Awake()
    {
        if (instance == null)
        {
            instance = this;
            DontDestroyOnLoad(this.gameObject);

            this.bgm = transform.Find("BGM Player").GetComponent<AudioSource>();

            var seParent = transform.Find("SE Players");
            for (int i = 0; i < this.canPlaySECount; i++) {
                var se = new GameObject("SE");
                se.transform.SetParent(seParent);

                var seSource = se.AddComponent<AudioSource>();
                var sePlayer = se.AddComponent<SEPlayer>();
                sePlayer.Init(seSource);
                this.unusedSEGameObject.Add(sePlayer);
            }
        }
        else
            Destroy(this.gameObject);
    }

    void PlayBackGroundMusic(AudioClip clip)
    {

        // 停止
        if (this.bgm.isPlaying) StopBackGroundMusic();

        // 再生
        this.bgm.clip = clip;
        this.bgm.Play();
    }

    void StopBackGroundMusic()
    {
        this.bgm.Stop();
    }

    void PlaySoundEffect(AudioClip clip)
    {
        if (this.unusedSEGameObject.Count > 0)
        {
            SEPlayer se = this.unusedSEGameObject[0];
            se.Play(clip);
            this.unusedSEGameObject.RemoveAt(0);
            this.usedSEGameObject.Add(se);
        }
    }

    //------------------------------
    // SE自身が終わったことを報告
    //------------------------------
    void EndPlaySE(SEPlayer se)
    {
        this.usedSEGameObject.Remove(se);
        this.unusedSEGameObject.Add(se);
    }
}
