using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Obstacle : MonoBehaviour
{
    public float highPosY = 1.5f;
    public float lowPosY = -1.5f;

    public float holeSizeMin = 1f;
    public float holeSizeMax = 3f;

    public Transform topObject;
    public Transform bottomObject;

    public float widthPadding = 8f;

    public GameObject coin;

    public Vector3 SetRandomPlace(Vector3 lastPosition, int obstaclCount) //장애물 위치 생성
    {
        CoinDestroy();

        float holeSize = Random.Range(holeSizeMin, holeSizeMax);
        float halfHoleSize = holeSize / 2f;

        // 장애물 위치
        topObject.localPosition = new Vector3(2f, halfHoleSize);
        bottomObject.localPosition = new Vector3(0, -halfHoleSize);

        Vector3 placePosition = lastPosition + new Vector3(widthPadding, 0); // 그 전 장애물 보다 widthPadding 떨어지게 생성
        placePosition.y = Random.Range(lowPosY, highPosY); // 장애물 높낮이 변경
        
        transform.position = placePosition;

        // 코인 생성
        float coinPos = Random.Range(1.4f, 2.5f);

        GameObject topCoin = Instantiate(coin);
        topCoin.transform.parent = this.transform;
        topCoin.transform.localPosition = new Vector2(topObject.localPosition.x + 0.1f, topObject.localPosition.y - coinPos);

        GameObject bottomCoin = Instantiate(coin);
        bottomCoin.transform.parent = this.transform;
        bottomCoin.transform.localPosition = new Vector2(bottomObject.localPosition.x + 0.1f, bottomObject.localPosition.y + coinPos);

        return placePosition;
    }
    
    private void CoinDestroy() // 코인 삭제
    {
        CoinController[] _coin = GetComponentsInChildren<CoinController>();
        if(_coin != null)
        {
            foreach(CoinController coin in _coin)
            {
                Destroy(coin.gameObject);
            }
        }
    }

    private void OnTriggerExit2D(Collider2D collision)
    {
        MiniGamePlayer_1 player = collision.GetComponent<MiniGamePlayer_1>();

        if (player != null)
        {
            //gameManager.AddScore(1);
        }
    }
}
