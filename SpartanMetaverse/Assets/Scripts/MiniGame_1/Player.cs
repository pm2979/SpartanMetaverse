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
            // 키를 누르고 있으면 위로 상승
            // 아니면 하강
            if (Input.GetKey(KeyCode.Space))
            {
                isFlap = true;
            }
        }
    }

    private void FixedUpdate()
    {
        if (isDead) return; // 죽으면 return

        Vector3 velocity = _rb.velocity;
        velocity.x = forwardSpeed; // 계속 앞으로 이동

        if (isFlap)
        {
            velocity.y += flapForce; // 위로 이동
            isFlap = false;
        }

        _rb.velocity = velocity; // 구조체이기 때문에 값을 넣어준다.

        float angle = Mathf.Clamp(_rb.velocity.y * 10f, -90, 90); // angle의 최소치와 최대치를 정한다
        transform.rotation = Quaternion.Euler(0, 0, angle); // z축 회전
    }


    private void OnCollisionEnter2D(Collision2D col) // 충돌
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
        Debug.Log("장애물 충돌");
    }

    private void OnTriggerExit2D(Collider2D col)
    {
        if (col.CompareTag("Coin")) // 코인 회득 시
        {
            int _coinValue = col.GetComponent<CoinController>().CoinValue;
            ScoreManager.Instance.AddScore(_coinValue); // 스코어 매니저에서 점수 상승
            Destroy(col.gameObject);

        }
    }
}
