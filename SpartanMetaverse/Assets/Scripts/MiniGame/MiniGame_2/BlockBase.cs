using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BlockBase : MonoBehaviour
{
    [SerializeField] private int hp = 1;
    [SerializeField] private GameObject coin;

    public void TakeDamage()
    {
        coin.GetComponent<Rigidbody2D>().gravityScale = 1;
        
        hp -= 1;

        if (hp == 0) StartCoroutine(Die());
    }

    private IEnumerator Die()
    {
        yield return new WaitForSeconds(0.01f);
        
        Instantiate(coin, transform.position, Quaternion.identity);
        
        Destroy(gameObject);
    }

}
