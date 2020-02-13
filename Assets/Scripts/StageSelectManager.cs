using UnityEngine;

public class StageSelectManager : MonoBehaviour
{
    public void LoadGame01()
    {
        SceneLoader.LoadScene(SceneLoader.Scenes.Game01);
    }

    public void LoadGame02()
    {
        SceneLoader.LoadScene(SceneLoader.Scenes.Game02);
    }

    public void LoadGame03()
    {
        SceneLoader.LoadScene(SceneLoader.Scenes.Game03);
    }
}
