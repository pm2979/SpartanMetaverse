using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraTracing : MonoBehaviour
{
    public Transform target;      // ���� ��� (�÷��̾�)
    public GameObject minBoundsObj;
    public GameObject maxBoundsObj;
    public float smoothSpeed = 5f; // �ε巯�� �̵� �ӵ�
    public Vector2 minBounds;     // ī�޶� ������ �� �ִ� �ּ� ��ġ
    public Vector2 maxBounds;     // ī�޶� ������ �� �ִ� �ִ� ��ġ

    private Vector3 offset;       // ī�޶�� �÷��̾� ���� �ʱ� �Ÿ�

    void Start()
    {
        // �ʱ� �Ÿ� ���� (���� z �ุ -10)
        offset = transform.position - target.position;

        if(minBoundsObj != null)
            minBounds = minBoundsObj.transform.position;
        if (maxBoundsObj != null)
            maxBounds = maxBoundsObj.transform.position;
    }

    // LateUpdate()�� ����ϴ� ������ ��� ĳ���� �̵��� ���� �Ŀ� ī�޶� ���󰡴� ������ ����� ����
    void LateUpdate()
    {
        // ���󰡾� �� ��ġ ��� (z�� ����)
        Vector3 desiredPosition = target.position + offset;
        desiredPosition.z = transform.position.z;


        // ��ġ ���� ����
        if(maxBoundsObj != null && minBoundsObj != null)
        {
            desiredPosition.x = Mathf.Clamp(desiredPosition.x, minBounds.x, maxBounds.x);
            desiredPosition.y = Mathf.Clamp(desiredPosition.y, minBounds.y, maxBounds.y);
        }

        // �ε巴�� �̵�
        transform.position = Vector3.Lerp(transform.position, desiredPosition, Time.deltaTime * smoothSpeed);
    }
}
