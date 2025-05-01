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

}
