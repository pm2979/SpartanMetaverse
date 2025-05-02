using UnityEngine;
using UnityEngine.SceneManagement;

public class MiniGameStartUI : BaseUI
{
    public string miniGameSceneName = "MinGame_1";
    protected override UIState GetUIState()
    {
        return UIState.MiniGameStart;
    }

    public void OnClickStartButton()
    {
        SceneManager.LoadScene(miniGameSceneName, LoadSceneMode.Single); // ¾À ºÒ·¯¿À±â
    }
}
