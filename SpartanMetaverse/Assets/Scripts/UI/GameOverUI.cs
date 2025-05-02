using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class GameOverUI : BaseUI
{
    private string mainScene = "Main";

    public void OnClickMainSceneButton()
    {
        SceneManager.LoadScene(mainScene, LoadSceneMode.Single); // 메인 씬 불러오기
    }

    public void OnClickReStartButton() // 미니게임 재시작 버튼
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().name); // 현재 씬 재시작
    }

    protected override UIState GetUIState()
    {
        return UIState.GameOver;
    }
}
