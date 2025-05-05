using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public abstract class BaseController : MonoBehaviour
{
    protected Rigidbody2D _rigidbody;

    public SpriteRenderer chracterRenderer;

    protected Vector2 movementDirection = Vector2.zero; // �̵� ����

    public Vector2 MovementDirection { get { return movementDirection; } }

    protected Vector2 lookDirection = Vector2.zero; // �ٶ󺸴� ����
    public Vector2 LookDirection { get { return lookDirection; } }
    protected AnimationHandler animationHandler;
    protected RidingController ridingController;

    protected virtual void Awake()
    {
        _rigidbody = GetComponent<Rigidbody2D>();
        animationHandler = GetComponent<AnimationHandler>();
        ridingController = GetComponent<RidingController>();
    }

    protected virtual void Update()
    {
    
    }

    protected virtual void FixedUpdate()
    {

    }

    protected virtual void HandleAction()
    {

    }

    protected abstract void Movement(Vector2 direction);


    protected void Rotate(Vector2 direction) // ȸ��
    {
        float rotZ = Mathf.Atan2(direction.y, direction.x) * Mathf.Rad2Deg;
        bool isLeft = Mathf.Abs(rotZ) > 90f; // ���� ������ Ȯ��

        chracterRenderer.flipX = isLeft; // ��������Ʈ �¿� ����
    }
}
