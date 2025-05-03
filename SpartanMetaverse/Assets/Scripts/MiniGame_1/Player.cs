using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : MonoBehaviour
{
    Animator animator;
    Rigidbody2D _rb;

    public float flapForce = 1f;
    public float forwardSpeed = 3f;
    public bool isDead = false;
    float deathCooldown = 0f;

    bool isFlap = false;

    public bool godMode = false;

    void Start()
    {
        animator = GetComponentInChildren<Animator>();
        _rb = GetComponent<Rigidbody2D>();

        if (animator == null)
            Debug.LogError("Not Founded Animator");

        if (_rb == null)
            Debug.LogError("Not Founded Rigidbody");
    }


    void Update()
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

    private void FixedUpdate()
    {
        if (isDead) return; // ������ return

        Vector3 velocity = _rb.velocity;
        velocity.x = forwardSpeed; // ��� ������ �̵�

        if (isFlap)
        {
            velocity.y += flapForce; // ���� �̵�
            isFlap = false;
        }

        _rb.velocity = velocity; // ����ü�̱� ������ ���� �־��ش�.

        float angle = Mathf.Clamp(_rb.velocity.y * 10f, -90, 90); // angle�� �ּ�ġ�� �ִ�ġ�� ���Ѵ�
        transform.rotation = Quaternion.Euler(0, 0, angle); // z�� ȸ��
    }


    private void OnCollisionEnter2D(Collision2D col) // �浹
    {
        if (godMode) return;

        if (isDead) return;

        if(col.gameObject.CompareTag("Obstacle")) //
        {
            isDead = true;
            deathCooldown = 1f;

            animator.SetInteger("IsDie", 1);
            MiniGameManager.Instance.GameOver();
        }
        Debug.Log("��ֹ� �浹");
    }

    private void OnTriggerExit2D(Collider2D col)
    {
        if (col.CompareTag("Coin")) // ���� ȸ�� ��
        {
            int _coinValue = col.GetComponent<CoinController>().CoinValue;
            ScoreManager.Instance.AddScore(_coinValue); // ���ھ� �Ŵ������� ���� ���
            Destroy(col.gameObject);

        }
    }
}
