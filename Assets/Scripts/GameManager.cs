using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManager : MonoBehaviour
{
    static GameManager instance;

    void Awake()
    {
        if (instance == null)
        {
            instance = this;
            DontDestroyOnLoad(this.gameObject);
        }
        else
            Destroy(this.gameObject);
    }

    void Update()
    {
        if (
            Input.GetKeyDown(KeyCode.Escape)                           &&
            !GameOverManager.IsActive                                  &&
            SceneLoader.LoadedScenes != SceneLoader.Scenes.Title       &&
            SceneLoader.LoadedScenes != SceneLoader.Scenes.StageSelect
        )
            GameOverManager.Active();
    }
}
