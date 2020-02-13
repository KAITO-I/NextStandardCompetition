using System;
using System.Collections;
using System.Text;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;
using TMPro;

//==============================
// シーン読み込み
//==============================
public class SceneLoader : MonoBehaviour
{
    static SceneLoader instance;
    public static Scenes LoadedScenes { get; private set; }

    public static bool IsLoading { get { return instance.isLoading; } }

    public static void LoadScene(Scenes target) {
        instance.Load(target);
    }

    //==============================
    // シーン一覧
    //==============================
    public enum Scenes
    {
        Title  = 0,
        StageSelect = 1,
        Game01 = 2,
        Game02 = 3,
        Game03 = 4
    }

    //==============================
    // class
    //==============================
    Image image;

    public bool isLoading { private set; get; }

    [SerializeField]
    float loadingTime;

    //------------------------------
    // 初期化
    //------------------------------
    void Awake()
    {
        if (instance == null)
        {
            instance = this;
            DontDestroyOnLoad(this.gameObject);

            LoadedScenes = (Scenes)Enum.ToObject(typeof(Scenes), SceneManager.GetActiveScene().buildIndex);

            this.image = transform.Find("Image").GetComponent<Image>();
            this.isLoading = false;
        }
        else
            Destroy(this.gameObject);
    }

    void Load(Scenes target)
    {
        if (!this.isLoading) StartCoroutine(LoadCoroutine(target));
        else                 Debug.LogWarning("すでにロード処理が開始しているため、新しく開始できません");
    }

    IEnumerator LoadCoroutine(Scenes target)
    {
        this.isLoading = true;

        #region タイトルからセレクトの場合のみ、フェードを発生させず移動
        if (LoadedScenes == Scenes.Title && target == Scenes.StageSelect)
        {
            // 読み込み
            AsyncOperation load = SceneManager.LoadSceneAsync((int)Scenes.StageSelect);
            load.allowSceneActivation = false;

            while (load.progress < 0.9f) yield return null;

            load.allowSceneActivation = true;
            LoadedScenes = target;
        }
        #endregion

        #region 上記以外はフェードを発生させて移動
        else
        {
            // 暗転
            float timer = 0f;
            while (timer <= this.loadingTime)
            {
                timer += Time.deltaTime;
                this.image.color = new Color(0f, 0f, 0f, Mathf.Lerp(0f, 1f, timer / this.loadingTime));
                yield return null;
            }

            // 読み込み
            AsyncOperation load = SceneManager.LoadSceneAsync((int)target);
            load.allowSceneActivation = false;

            while (load.progress < 0.9f) yield return null;

            load.allowSceneActivation = true;
            LoadedScenes = target;

            // 明転
            timer = 0f;
            while (timer <= this.loadingTime)
            {
                timer += Time.deltaTime;
                this.image.color = new Color(0f, 0f, 0f, Mathf.Lerp(1f, 0f, timer / this.loadingTime));
                yield return null;
            }
        }
        #endregion

        this.isLoading = false;
    }
}