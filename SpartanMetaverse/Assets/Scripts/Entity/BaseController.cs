using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public abstract class BaseController : MonoBehaviour
{
    protected Rigidbody2D _rigidbody;

    [SerializeField] protected SpriteRenderer chracterRenderer;

    protected Vector2 movementDirection = Vector2.zero; // 이동 방향

    public Vector2 MovementDirection { get { return movementDirection; } }

    protected Vector2 lookDirection = Vector2.zero; // 바라보는 방향
    public Vector2 LookDirection { get { return lookDirection; } }

    private Vector2 knockback = Vector2.zero; // 넉백 방향
    private float knockbackDuration = 0.0f; // 넉백 시간

    protected StatHandler statHandler;
    protected AnimationHandler animationHandler;

    protected virtual void Awake()
    {
        _rigidbody = GetComponent<Rigidbody2D>();
        statHandler = GetComponent<StatHandler>();
        animationHandler = GetComponent<AnimationHandler>();
    }

    protected virtual void Update()
    {
        HandleAction();
        Rotate(lookDirection);
    }

    protected virtual void FixedUpdate()
    {
        Movement(MovementDirection);
        if (knockbackDuration > 0.0f)
        {
            knockbackDuration -= Time.fixedDeltaTime;
        }
    }

    protected virtual void HandleAction()
    {

    }


    private void Movement(Vector2 direction) // 이동
    {
        direction = direction * statHandler.Speed; // 이동 속도
        if (knockbackDuration > 0.0f) // 넉백을 적용해야한다면
        {
            direction *= 0.2f; // 기존 이동 방향의 힘을 줄이고
            direction += knockback; // 넉백을 적용
        }

        _rigidbody.velocity = direction; // 실제 이동 적용
        animationHandler.Move(direction); // Move 애니메이션
    }

    private void Rotate(Vector2 direction) // 회전
    {
        float rotZ = Mathf.Atan2(direction.y, direction.x) * Mathf.Rad2Deg;
        bool isLeft = Mathf.Abs(rotZ) > 90f; // 왼쪽 오른쪽 확인

        chracterRenderer.flipX = isLeft; // 스프라이트 좌우 반전
    }
}
