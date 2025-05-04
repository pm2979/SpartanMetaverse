using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : MiniGameController
{
    public float flapForce = 1f;
    public float forwardSpeed = 3f;

    bool isFlap = false;

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
}
