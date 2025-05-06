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

    public Vector3 SetRandomPlace(Vector3 lastPosition, int obstaclCount) //��ֹ� ��ġ ����
    {
        CoinDestroy();

        float holeSize = Random.Range(holeSizeMin, holeSizeMax);
        float halfHoleSize = holeSize / 2f;

        // ��ֹ� ��ġ
        topObject.localPosition = new Vector3(2f, halfHoleSize);
        bottomObject.localPosition = new Vector3(0, -halfHoleSize);

        Vector3 placePosition = lastPosition + new Vector3(widthPadding, 0); // �� �� ��ֹ� ���� widthPadding �������� ����
        placePosition.y = Random.Range(lowPosY, highPosY); // ��ֹ� ������ ����
        
        transform.position = placePosition;

        // ���� ����
        float coinPos = Random.Range(1.4f, 2.5f);

        GameObject topCoin = Instantiate(coin);
        topCoin.transform.parent = this.transform;
        topCoin.transform.localPosition = new Vector2(topObject.localPosition.x + 0.1f, topObject.localPosition.y - coinPos);

        GameObject bottomCoin = Instantiate(coin);
        bottomCoin.transform.parent = this.transform;
        bottomCoin.transform.localPosition = new Vector2(bottomObject.localPosition.x + 0.1f, bottomObject.localPosition.y + coinPos);

        return placePosition;
    }
    
    private void CoinDestroy() // ���� ����
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
