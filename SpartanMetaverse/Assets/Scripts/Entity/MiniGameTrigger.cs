using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MiniGameTrigger : MonoBehaviour
{
    [SerializeField] private GameObject ui;

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if(collision.CompareTag("Player") == true) // 미니게임 시작 UI On
        {
            UIManager.Instance.SetMiniGameStart();
            ui.SetActive(true);
        }
    }

    private void OnTriggerExit2D(Collider2D Collision)
    {
        if (Collision.CompareTag("Player")) // 미니게임 시작 UI Off
        {
            UIManager.Instance.SetPlayGame();
            if(ui != null)
            ui.SetActive(false);
        }
    }
}
