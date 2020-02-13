using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.EventSystems;

public class GameOverManager : MonoBehaviour
{
    static GameOverManager instance;

    public static bool IsActive { get; private set; }

    public static void Active()
    {
        instance.Act();
    }

    GameObject stageSelectButtonObj;
    Button     stageselectButton;

    void Awake()
    {
        if (instance == null)
        {
            instance = this;
            DontDestroyOnLoad(this.gameObject);

            this.stageSelectButtonObj = transform.Find("StageSelect").gameObject;
            this.stageselectButton    = this.stageSelectButtonObj.GetComponent<Button>();

            gameObject.SetActive(IsActive = false);
        }
        else
            Destroy(this.gameObject);
    }

    void Act()
    {
        gameObject.SetActive(IsActive = true);
        EventSystem.current.SetSelectedGameObject(this.stageSelectButtonObj);
        this.stageselectButton.OnSelect(null);
    }

    public void StageSelect()
    {
        SceneLoader.LoadScene(SceneLoader.Scenes.StageSelect);
        gameObject.SetActive(IsActive = false);
    }

    public void Retry()
    {
        SceneLoader.LoadScene(SceneLoader.LoadedScenes);
        gameObject.SetActive(IsActive = false);
    }
}
