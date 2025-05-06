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

        // 2) ���� ���� ����
        var mat = new PhysicsMaterial2D { bounciness = 1f, friction = 0f };
        cc.sharedMaterial = mat;

        // rb.sharedMaterial�� �� ������ٵ� �����ؼ� ���� ���� ����
        // Physics Material 2D ������ �����ϴ� ���, �ڵ带 ���� ��Ÿ�ӿ� ��� �� ������ �Ҵ�
        // bounciness = 1f > ���� ���� �浹
        // friction = 0f > ������ 0
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
