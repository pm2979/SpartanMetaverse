using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : BaseController
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

        Movement(_rigidbody.velocity);
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

        _rigidbody.velocity = velocity; // ����ü�̱� ������ ���� �־��ش�.

        float angle = Mathf.Clamp(_rigidbody.velocity.y * 10f, -90, 90); // angle�� �ּ�ġ�� �ִ�ġ�� ���Ѵ�
        transform.rotation = Quaternion.Euler(0, 0, angle); // z�� ȸ��
    }

    protected virtual void OnCollisionEnter2D(Collision2D col) // �浹
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

    protected virtual void OnTriggerExit2D(Collider2D col)
    {
        if (col.CompareTag("Coin")) // ���� ȸ�� ��
        {
            int _coinValue = col.GetComponent<CoinController>().CoinValue;
            ScoreManager.Instance.AddScore(_coinValue); // ���ھ� �Ŵ������� ���� ���
            Destroy(col.gameObject);

        }
    }
}
