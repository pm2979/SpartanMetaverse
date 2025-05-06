using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public abstract class BaseController : MonoBehaviour
{
    protected Rigidbody2D rb;

    public SpriteRenderer chracterRenderer;

    protected Vector2 movementDirection = Vector2.zero; // 이동 방향

    public Vector2 MovementDirection { get { return movementDirection; } }

    protected Vector2 lookDirection = Vector2.zero; // 바라보는 방향
    public Vector2 LookDirection { get { return lookDirection; } }
    protected AnimationHandler animationHandler;
    protected RidingController ridingController;

    protected virtual void Awake()
    {
        rb = GetComponent<Rigidbody2D>();
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


    protected void Rotate(Vector2 direction) // 회전
    {
        float rotZ = Mathf.Atan2(direction.y, direction.x) * Mathf.Rad2Deg;
        bool isLeft = Mathf.Abs(rotZ) > 90f; // 왼쪽 오른쪽 확인

        chracterRenderer.flipX = isLeft; // 스프라이트 좌우 반전

        if(ridingController.IsRide == true)
        {
            ridingController.VehicleRotate(isLeft);
        }
    }

    protected virtual void OnTriggerEnter2D(Collider2D col)
    {
        if (col.CompareTag("Coin")) // 코인 회득 시
        {
            int _coinValue = col.GetComponent<CoinController>().CoinValue;
            ScoreManager.Instance.AddScore(_coinValue); // 스코어 매니저에서 점수 상승
            Destroy(col.gameObject);

        }
    }
}
