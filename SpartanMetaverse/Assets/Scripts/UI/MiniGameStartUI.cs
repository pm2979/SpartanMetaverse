using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class MiniGameStartUI : BaseUI
{
    protected override UIState GetUIState()
    {
        return UIState.MiniGameStart;
    }

    public void OnClickGoMiniGame(string miniGameSceneName)
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
