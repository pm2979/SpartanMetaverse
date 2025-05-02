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

    public void GameOver() // 미니게임 종료
    {
        uiManager.SetGameOver();
    }

    public void RestartGame() // 미니게임 재시작
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().name); // 현재 씬 재시작
    }
}
