using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Wall : MonoBehaviour
{
    private Rigidbody2D rb;

    private void Awake()
    {
        rb = GetComponent<Rigidbody2D>();

        // 2) ���� ���� ����
        rb.sharedMaterial = new PhysicsMaterial2D { bounciness = 1f, friction = 0f };

    }
}
