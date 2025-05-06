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
        ballDirection = Vector2.up.normalized; // 공의 초기 이동 방향
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
            float hitPoint = col.contacts[0].point.x;
            float paddleCenter = col.transform.position.x;
            float angle = (hitPoint - paddleCenter) * 2.0f;

            ballDirection = new Vector2(Mathf.Sin(angle), Mathf.Cos(angle)).normalized;
        }
    }

    private void OnTriggerEnter2D(Collider2D col)
    {
        if (col.CompareTag("Block"))
        {
            col.gameObject.GetComponent<BlockBase>().TakeDamage();
        }
    }
}
