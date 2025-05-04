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
}
