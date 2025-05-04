using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : BaseController
{
    private int coin;
    public int Coin { get => coin; set => coin = value; }

    private Camera _camera;

    protected StatHandler statHandler;

    public void Init()
    {
        _camera = Camera.main;
        statHandler = GetComponent<StatHandler>();
    }

    protected override void Update()
    {
        HandleAction();
        Rotate(lookDirection);
    }

    protected override void FixedUpdate()
    {
        if (chracterRenderer != null)
            Movement(MovementDirection);
    }

    protected override void HandleAction()
    {
        // �Էµ� �� ��������
        float horizontal = Input.GetAxisRaw("Horizontal"); //  A �� D
        float vertical = Input.GetAxisRaw("Vertical"); // S �� W

        // ���� ���͸� ������ ������
        movementDirection = new Vector2(horizontal, vertical).normalized;

        Vector2 mousePosition = Input.mousePosition;
        Vector2 worldPos = _camera.ScreenToWorldPoint(mousePosition);
        lookDirection = (worldPos - (Vector2)transform.position);

        // ���� ��ġ�κ��� ���콺 ��ġ������ ���� ���
        if (lookDirection.magnitude < .9f)
        {
            lookDirection = Vector2.zero;
        }
        else
        {
            lookDirection = lookDirection.normalized;
        }
    }

    protected override void Movement(Vector2 direction) // �̵�
    {
        direction = direction * statHandler.Speed; // �̵� �ӵ�

        _rigidbody.velocity = direction; // ���� �̵� ����

        if (animationHandler != null)
            animationHandler.Move(direction, AnimatorType.Player); // Move �ִϸ��̼�
    }
}
