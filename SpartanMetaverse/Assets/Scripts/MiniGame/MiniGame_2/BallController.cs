using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BallController : MonoBehaviour
{
    public float ballSpeed = 5f;

    private Vector2 ballDirection; // 공 이동 방향

    private Rigidbody2D rb;

    private void Awake()
    {
        rb = GetComponent<Rigidbody2D>();
        rb.gravityScale = 0f;

    }

    private void Start()
    {
        ballDirection = Vector2.up; // 공의 초기 이동 방향
    }

    private void Update()
    {
        transform.Translate(ballDirection * ballSpeed * Time.deltaTime);
    }

    private void OnCollisionEnter2D(Collision2D col)
    {
        if(col.gameObject.CompareTag("Wall"))
        {
            ballDirection = Vector2.Reflect(ballDirection, col.contacts[0].normal);
        }
        else if(col.gameObject.CompareTag("Player"))
        {
            ballDirection = Vector2.Reflect(ballDirection, col.contacts[0].normal);
        }
        else if (col.gameObject.CompareTag("Block"))
        {
            ballDirection = Vector2.Reflect(ballDirection, col.contacts[0].normal);
            col.gameObject.GetComponent<BlockBase>().TakeDamage();
        }
        else if(col.gameObject.CompareTag("Ground"))
        {
            MiniGameManager.Instance.GameOver();
        }
    }
}
