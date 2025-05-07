using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BlockBase : MonoBehaviour
{
    [SerializeField] private int hp = 1;
    [SerializeField] private GameObject coin;

    public void TakeDamage()
    {
        coin.GetComponent<Rigidbody2D>().gravityScale = 0.1f;
       

        hp -= 1;

        if (hp == 0) StartCoroutine(Die());
    }

    private IEnumerator Die()
    {
        yield return new WaitForSeconds(0.01f);
        
        if(Random.value < 0.5f)
        {
            Instantiate(coin, transform.position, Quaternion.identity);
        }

        this.GetComponentInParent<BlockSpawnController>().blocks -= 1;
        Destroy(gameObject);
    }

}
