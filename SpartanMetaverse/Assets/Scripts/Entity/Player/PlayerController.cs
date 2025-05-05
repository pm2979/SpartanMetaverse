using System.Collections;
using System.Collections.Generic;
using System.ComponentModel;
using UnityEngine;

public class PlayerController : BaseController
{
    [SerializeField] private int moveSpeed = 3;
    [SerializeField] private int ridingSpeed = 5;
    private int coin;
    public int Coin { get => coin; set => coin = value; }

    private Camera _camera;
    private StatHandler statHandler;

    public void Init()
    {
        _camera = Camera.main;
        statHandler = GetComponent<StatHandler>();
    }

    protected override void Update()
    {
        HandleAction();
        Rotate(lookDirection);

        if (Input.GetKeyDown(KeyCode.V)) // ž�� Ű
        {
            if (ridingController.IsRide == false) // ž�� on
            {
                ridingController.VehicleOn();
                ridingController.VehicleScaleUp();

                chracterRenderer.transform.localPosition = new Vector3(0, 1);
                statHandler.Speed = ridingSpeed;
            }
            else // ž�� off
            {
                ridingController.VehicleOff();

                chracterRenderer.transform.localPosition = new Vector3(0, 0.4f);
                statHandler.Speed = moveSpeed;
            }
        }
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
