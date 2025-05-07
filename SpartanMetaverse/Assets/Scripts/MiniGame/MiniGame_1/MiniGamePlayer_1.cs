using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MiniGamePlayer_1 : BaseController
{
    public float flapForce = 1f;
    public float forwardSpeed = 3f;

    bool isFlap = false;

    float deathCooldown = 0f;
    public bool isDead = false;
    public bool godMode = false;

    private void Start()
    {
        chracterRenderer.gameObject.transform.localPosition = new Vector3(0, 0.6f, 0);
        chracterRenderer.gameObject.transform.localScale = new Vector3(0.5f, 0.5f, 1);

        ridingController.VehicleOn();
    }

    protected override void Update()
    {
        if (!isDead)
        {
            // Ű�� ������ ������ ���� ���
            // �ƴϸ� �ϰ�
            if (Input.GetKey(KeyCode.Space))
            {
                isFlap = true;
            }
        }
    }

    protected override void FixedUpdate()
    {
        if (isDead) return; // ������ return

        Movement(rb.velocity);
    }

    protected override void Movement(Vector2 direction)
    {
        Vector2 velocity = direction;
        velocity.x = forwardSpeed; // ��� ������ �̵�

        if (isFlap)
        {
            velocity.y += flapForce; // ���� �̵�
            isFlap = false;
        }

        rb.velocity = velocity; // ����ü�̱� ������ ���� �־��ش�.

        float angle = Mathf.Clamp(rb.velocity.y * 10f, -90, 90); // angle�� �ּ�ġ�� �ִ�ġ�� ���Ѵ�
        transform.rotation = Quaternion.Euler(0, 0, angle); // z�� ȸ��
    }

    private void OnCollisionEnter2D(Collision2D col)
    {
        if (godMode) return;

        if (isDead) return;


        if (col.gameObject.CompareTag("Obstacle"))
        {
            isDead = true;
            deathCooldown = 1f;

            animationHandler.Die(AnimatorType.Vehcle);
            animationHandler.Damage();
            MiniGameManager.Instance.GameOver();
        }
    }

}
