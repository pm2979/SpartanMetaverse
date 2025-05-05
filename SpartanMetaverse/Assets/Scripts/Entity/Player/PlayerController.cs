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

        if (Input.GetKeyDown(KeyCode.V)) // 탑승 키
        {
            if (ridingController.IsRide == false) // 탑승 on
            {
                ridingController.VehicleOn();
                ridingController.VehicleScaleUp();

                chracterRenderer.transform.localPosition = new Vector3(0, 1);
                statHandler.Speed = ridingSpeed;
            }
            else // 탑승 off
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
        // 입력된 값 가져오기
        float horizontal = Input.GetAxisRaw("Horizontal"); //  A 와 D
        float vertical = Input.GetAxisRaw("Vertical"); // S 와 W

        // 방향 벡터를 일정한 값으로
        movementDirection = new Vector2(horizontal, vertical).normalized;

        Vector2 mousePosition = Input.mousePosition;
        Vector2 worldPos = _camera.ScreenToWorldPoint(mousePosition);
        lookDirection = (worldPos - (Vector2)transform.position);

        // 현재 위치로부터 마우스 위치까지의 방향 계산
        if (lookDirection.magnitude < .9f)
        {
            lookDirection = Vector2.zero;
        }
        else
        {
            lookDirection = lookDirection.normalized;
        }
    }

    protected override void Movement(Vector2 direction) // 이동
    {
        direction = direction * statHandler.Speed; // 이동 속도

        _rigidbody.velocity = direction; // 실제 이동 적용

        if (animationHandler != null)
            animationHandler.Move(direction, AnimatorType.Player); // Move 애니메이션
    }
}
