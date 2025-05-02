using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public enum UIState
{
    MiniGameStart,
    Game,
    GameOver,
}

public class UIManager : Singleton<UIManager>
{
    private UIState currentState;

    [SerializeField]private List<BaseUI> uiList;


    protected override void Awake()
    {
        SceneAwake();
        SceneManager.sceneLoaded -= OnSceneLoaded;
        SceneManager.sceneLoaded += OnSceneLoaded;

        ChangeState(UIState.Game);
    }

    // 씬 로드 후 자동 호출
    private void OnSceneLoaded(Scene scene, LoadSceneMode mode)
    {
        SceneAwake();
        ChangeState(UIState.MiniGameStart);
    }

    public void SetMiniGameStart()
    {
        ChangeState(UIState.MiniGameStart);
    }

    public void SetPlayGame()
    {
        ChangeState(UIState.Game);
    }

    public void SetGameOver()
    {
        ChangeState(UIState.GameOver);
    }

    public void ChangePlayerHP(float currentHP, float maxHP)
    {
        //miniGameStartUI.UpdateHPSlider(currentHP / maxHP);
    }

    public void ChangeState(UIState state)
    {
        currentState = state;
        foreach (var ui in uiList)
        {
            ui.SetActive(currentState);
        }
    }


    public void SceneAwake() // Awake에서 해야 할 것들
    {
        uiList = new List<BaseUI>(FindObjectsOfType<BaseUI>(true));

        foreach (var ui in uiList)
        {
            ui.Init(this);
        }
    }
}
