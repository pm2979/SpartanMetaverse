using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MiniGamePlayer_2 : BaseController
{
    [SerializeField] private float jumpHeight = 1f;
    [SerializeField] private float jumpDuration = 0.4f;
    private bool isJump;
    
    private Camera _camera;
    private StatHandler statHandler;

    float deathCooldown = 0f;
    public bool isDead = false;

    private Vector3 playerPos;

    protected override void Awake()
    {
        base.Awake();

        _camera = Camera.main;
        statHandler = GetComponent<StatHandler>();

        playerPos = transform.position;
        isJump = true;
    }

    protected override void Update()
    {
        if (!isDead && isJump == true)
        {
            HandleAction();
            Rotate(lookDirection);

            Movement(MovementDirection);

            if (Input.GetKey(KeyCode.Space))
            {
                StartCoroutine(Jump());
            }
        }
    }

    protected override void FixedUpdate()
    {

    }

    protected override void HandleAction()
    {
        // 입력된 값 가져오기
        float horizontal = Input.GetAxisRaw("Horizontal"); //  A 와 D

        // 방향 벡터를 일정한 값으로
        movementDirection = new Vector2(horizontal, 0).normalized;

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
        playerPos.x += direction.x * statHandler.Speed * Time.deltaTime; // 이동 속도
        playerPos.x = Mathf.Clamp(playerPos.x, -3.4f, 3.4f);

        transform.position = playerPos;

        if (animationHandler != null)
            animationHandler.Move(direction, AnimatorType.Player); // Move 애니메이션
    }

    private IEnumerator Jump()
    {
        isJump = false;
        Vector3 startPos = transform.position;
        Vector3 peakPos = startPos + Vector3.up * jumpHeight;

        // 상승
        float _jumpDuration = 0f;
        while (_jumpDuration < jumpDuration)
        {
            transform.position = Vector3.Lerp(startPos, peakPos, _jumpDuration / jumpDuration);
            _jumpDuration += Time.deltaTime;
            yield return null;
        }

        // 하강
        _jumpDuration = 0f;
        while (_jumpDuration < jumpDuration)
        {
            transform.position = Vector3.Lerp(peakPos, startPos, _jumpDuration / jumpDuration);
            _jumpDuration += Time.deltaTime;
            yield return null;
        }

        transform.position = startPos; // 오차 보정
        isJump = true;
    }

    protected override void OnTriggerEnter2D(Collider2D col)
    {
        if (isDead) return;

        base.OnTriggerEnter2D(col);
    }

    private void OnCollisionEnter2D(Collision2D col)
    {
        if (isDead)
        {
            isJump = false;
            return;
        }
    }
}
