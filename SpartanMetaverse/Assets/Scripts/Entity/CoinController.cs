using JetBrains.Annotations;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CoinController : MonoBehaviour
{
    [SerializeField] private CoinType[] coinTypes;
    [SerializeField] private SpriteRenderer typeSprite;

    private int coinValue = 0;
    public int CoinValue {  get => coinValue; private set =>  coinValue = value; }


    
    private void Start()
    {
        int randomCoin = Random.Range(0, coinTypes.Length);

        coinValue = coinTypes[randomCoin].coinValue;
        typeSprite.sprite = coinTypes[randomCoin].typeSprite;
    }


    private void OnTriggerEnter2D(Collider2D col)
    {
        if(col.CompareTag("Player") == true)
        {
            Destroy(this.gameObject);
        }
    }

}

[System.Serializable] // 인스펙터 노출
public struct CoinType
{
    public int coinValue;
    public Sprite typeSprite;
}
