using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class MiniGameStartUI : BaseUI
{
    public string miniGameSceneName = "MinGame_1";
    protected override UIState GetUIState()
    {
        return UIState.MiniGameStart;
    }

    public void OnClickGoMiniGame()
    {
        SceneManager.LoadScene(miniGameSceneName, LoadSceneMode.Single); // ¾À ºÒ·¯¿À±â
    }

    public void OnClickMiniGameStart()
    {
        Time.timeScale = 1.0f;
        this.gameObject.SetActive(false);
        UIManager.Instance.SetPlayGame();
    }
}
