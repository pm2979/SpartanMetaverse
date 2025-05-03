using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BgLooper : MonoBehaviour
{
    public int numBgCount = 5;
    public int obstacleCount = 0;
    public Vector3 obstacleLastPosition = Vector3.zero;

    void Start()
    {
        Obstacle[] obstacles = GameObject.FindObjectsOfType<Obstacle>(); // ��� Obstacle ������Ʈ�� ã�´�
        obstacleLastPosition = obstacles[0].transform.position;
        obstacleCount = obstacles.Length;

        for (int i = 0; i < obstacleCount; i++) // �迭�� ��� ��ֹ� ��ġ
        {
            obstacleLastPosition = obstacles[i].SetRandomPlace(obstacleLastPosition, obstacleCount);
        }


    }

    private void OnTriggerEnter2D(Collider2D col)
    {
        Debug.Log("Triggerd: " + col.name);

        if (col.CompareTag("BackGround")) // ��� ���ġ
        {
            float widtOfBgObject = ((BoxCollider2D)col).size.x; // ��� ������ �޾ƿ���
            Vector3 pos = col.transform.position;

            pos.x += widtOfBgObject * numBgCount;
            col.transform.position = pos;
            return;
        }

        Obstacle obstacle = col.GetComponent<Obstacle>();

        if (obstacle) // ������ ��ü�� Obstaccle�̶��
        {
            obstacleLastPosition = obstacle.SetRandomPlace(obstacleLastPosition, obstacleCount); // ��ֹ� ��ġ
        }

        if(col.CompareTag("Coin") == true)
        {
            Destroy(col.gameObject);
        }
    }
}
