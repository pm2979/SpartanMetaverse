using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BallController : MonoBehaviour
{
    public float speed = 5f;

    private Rigidbody2D rb;
    private CircleCollider2D cc;

    private void Awake()
    {
        rb = GetComponent<Rigidbody2D>();
        cc = GetComponent<CircleCollider2D>();
        rb.gravityScale = 0f;

        rb.collisionDetectionMode = CollisionDetectionMode2D.Continuous;

        // 2) 물리 재질 설정
        var mat = new PhysicsMaterial2D { bounciness = 1f, friction = 0f };
        cc.sharedMaterial = mat;

        // rb.sharedMaterial은 이 리지드바디가 공유해서 쓰는 물리 재질
        // Physics Material 2D 에셋을 연결하는 대신, 코드를 통해 런타임에 즉시 새 재질을 할당
        // bounciness = 1f > 완전 탕성 충돌
        // friction = 0f > 마찰력 0
    }

    private void Start()
    {
        Launch();
    }

    private void Launch()
    {
        float angle = Random.Range(-45f, 45f) * Mathf.Deg2Rad;
        Vector2 direction = new Vector2(Mathf.Cos(angle), Mathf.Sin(angle)).normalized;
        rb.velocity = direction * speed;
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        ContactPoint2D contact = collision.contacts[0];
        Vector2 reflected = Vector2.Reflect(rb.velocity.normalized, contact.normal);
        rb.velocity = reflected * speed;
    }
}
