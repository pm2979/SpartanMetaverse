using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LeaderBoard : MonoBehaviour
{
    [SerializeField] private LeaderBoardUI leaderBoardUI;
    [SerializeField] private string highScore;
    [SerializeField] private string gameName;
    
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.CompareTag("Player") == true) // 리더보드 On
        {
            leaderBoardUI.highScore = highScore;
            leaderBoardUI.gameName = gameName;

            UIManager.Instance.SetLeaderBoard();

        }
    }

    private void OnTriggerExit2D(Collider2D Collision)
    {
        if (Collision.CompareTag("Player")) // 리더보드 Off
        {
            UIManager.Instance.SetPlayGame();
        }
    }
}
