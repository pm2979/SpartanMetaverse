using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class MiniGameManager : Singleton<MiniGameManager>
{

    UIManager uiManager;

    protected override void Awake()
    {
        base.Awake();

        uiManager = FindObjectOfType<UIManager>();

        Time.timeScale = 0f;
    }


}
