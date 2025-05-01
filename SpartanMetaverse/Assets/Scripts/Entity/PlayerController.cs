using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : BaseController
{
    private Camera _camera;
    private GameManager gameManager;

    public void Init(GameManager gameManager)
    {
        this.gameManager = gameManager;
        _camera = Camera.main;
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

}
