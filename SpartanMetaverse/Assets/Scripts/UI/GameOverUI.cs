using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class GameOverUI : BaseUI
{
    private string mainScene = "Main";

    public void OnClickMainSceneButton()
    {
        SceneManager.LoadScene(mainScene, LoadSceneMode.Single); // ���� �� �ҷ�����
    }

    public void OnClickReStartButton() // �̴ϰ��� ����� ��ư
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().name); // ���� �� �����
    }

    protected override UIState GetUIState()
    {
        return UIState.GameOver;
    }
}
