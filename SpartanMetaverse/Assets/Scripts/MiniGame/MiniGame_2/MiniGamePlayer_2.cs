using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MiniGamePlayer_2 : BaseController
{
    private Camera _camera;
    private StatHandler statHandler;
    bool isJump = false;

    float deathCooldown = 0f;
    public bool isDead = false;

    private Vector3 playerPos;

    protected override void Awake()
    {
        base.Awake();

        _camera = Camera.main;
        statHandler = GetComponent<StatHandler>();

        playerPos = transform.position;
    }

    protected override void Update()
    {
        if (!isDead)
        {
            HandleAction();
            Rotate(lookDirection);
        }
    }

    protected override void FixedUpdate()
    {
        if (chracterRenderer != null)
        {
            Movement(MovementDirection);

            if (Input.GetKey(KeyCode.Space) && isJump == true)
            {
                Jump();
            }
        }
    }

    protected override void HandleAction()
    {
        // �Էµ� �� ��������
        float horizontal = Input.GetAxisRaw("Horizontal"); //  A �� D

        // ���� ���͸� ������ ������
        movementDirection = new Vector2(horizontal, 0).normalized;

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
        playerPos.x += direction.x * statHandler.Speed * Time.deltaTime; // �̵� �ӵ�
        playerPos.x = Mathf.Clamp(playerPos.x, -3.4f, 3.4f);

        transform.position = playerPos;

        if (animationHandler != null)
            animationHandler.Move(direction, AnimatorType.Player); // Move �ִϸ��̼�
    }

    private void Jump()
    {
        if (isJump == true)
        {
            rb.velocity = Vector2.up * 5;

            isJump = false;
        }
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

        if (col.gameObject.CompareTag("Ground") && isJump == false)
        {
            isJump = true;
        }
    }
}
