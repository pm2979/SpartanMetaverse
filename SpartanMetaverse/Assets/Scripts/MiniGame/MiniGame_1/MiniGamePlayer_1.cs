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
            // 키를 누르고 있으면 위로 상승
            // 아니면 하강
            if (Input.GetKey(KeyCode.Space))
            {
                isFlap = true;
            }
        }
    }

    protected override void FixedUpdate()
    {
        if (isDead) return; // 죽으면 return

        Movement(rb.velocity);
    }

    protected override void Movement(Vector2 direction)
    {
        Vector2 velocity = direction;
        velocity.x = forwardSpeed; // 계속 앞으로 이동

        if (isFlap)
        {
            velocity.y += flapForce; // 위로 이동
            isFlap = false;
        }

        rb.velocity = velocity; // 구조체이기 때문에 값을 넣어준다.

        float angle = Mathf.Clamp(rb.velocity.y * 10f, -90, 90); // angle의 최소치와 최대치를 정한다
        transform.rotation = Quaternion.Euler(0, 0, angle); // z축 회전
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
