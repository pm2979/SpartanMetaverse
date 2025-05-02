using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class MiniGameManager : Singleton<MiniGameManager>
{
    UIManager uiManager;

    protected override void Awake()
    {
        uiManager = FindObjectOfType<UIManager>();

        Time.timeScale = 0f;
        //uiManager.SetMiniGameStart(); // StartUI
    }

    private void Start()
    {
        uiManager.SetMiniGameStart(); // StartUI
    }

    public void GameOver() // �̴ϰ��� ����
    {
        uiManager.SetGameOver();
    }

    public void RestartGame() // �̴ϰ��� �����
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().name); // ���� �� �����
    }
}
