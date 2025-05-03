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
        Obstacle[] obstacles = GameObject.FindObjectsOfType<Obstacle>(); // 모든 Obstacle 오브젝트를 찾는다
        obstacleLastPosition = obstacles[0].transform.position;
        obstacleCount = obstacles.Length;

        for (int i = 0; i < obstacleCount; i++) // 배열의 모든 장애물 배치
        {
            obstacleLastPosition = obstacles[i].SetRandomPlace(obstacleLastPosition, obstacleCount);
        }


    }

    private void OnTriggerEnter2D(Collider2D col)
    {
        Debug.Log("Triggerd: " + col.name);

        if (col.CompareTag("BackGround")) // 배경 재배치
        {
            float widtOfBgObject = ((BoxCollider2D)col).size.x; // 배경 사이즈 받아오기
            Vector3 pos = col.transform.position;

            pos.x += widtOfBgObject * numBgCount;
            col.transform.position = pos;
            return;
        }

        Obstacle obstacle = col.GetComponent<Obstacle>();

        if (obstacle) // 접촉한 물체가 Obstaccle이라면
        {
            obstacleLastPosition = obstacle.SetRandomPlace(obstacleLastPosition, obstacleCount); // 장애물 배치
        }

        if(col.CompareTag("Coin") == true)
        {
            Destroy(col.gameObject);
        }
    }
}
