using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraTracing : MonoBehaviour
{
    public Transform target;      // 따라갈 대상 (플레이어)
    public GameObject minBoundsObj;
    public GameObject maxBoundsObj;
    public float smoothSpeed = 5f; // 부드러운 이동 속도
    public Vector2 minBounds;     // 카메라가 도달할 수 있는 최소 위치
    public Vector2 maxBounds;     // 카메라가 도달할 수 있는 최대 위치

    private Vector3 offset;       // 카메라와 플레이어 간의 초기 거리

    void Start()
    {
        // 초기 거리 설정 (보통 z 축만 -10)
        offset = transform.position - target.position;

        if(minBoundsObj != null)
            minBounds = minBoundsObj.transform.position;
        if (maxBoundsObj != null)
            maxBounds = maxBoundsObj.transform.position;
    }

    // LateUpdate()를 사용하는 이유는 모든 캐릭터 이동이 끝난 후에 카메라가 따라가는 연출을 만들기 위함
    void LateUpdate()
    {
        // 따라가야 할 위치 계산 (z는 유지)
        Vector3 desiredPosition = target.position + offset;
        desiredPosition.z = transform.position.z;


        // 위치 제한 적용
        if(maxBoundsObj != null && minBoundsObj != null)
        {
            desiredPosition.x = Mathf.Clamp(desiredPosition.x, minBounds.x, maxBounds.x);
            desiredPosition.y = Mathf.Clamp(desiredPosition.y, minBounds.y, maxBounds.y);
        }

        // 부드럽게 이동
        transform.position = Vector3.Lerp(transform.position, desiredPosition, Time.deltaTime * smoothSpeed);
    }
}
