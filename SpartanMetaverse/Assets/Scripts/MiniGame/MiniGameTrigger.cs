using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MiniGameTrigger : MonoBehaviour
{
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if(collision.CompareTag("Player") == true) // 미니게임 시작 UI On
        {

        }
    }

    private void OnTriggerExit2D(Collider2D Collision)
    {
        if (Collision.CompareTag("Player")) // 미니게임 시작 UI Off
        {
            
        }
    }
}
