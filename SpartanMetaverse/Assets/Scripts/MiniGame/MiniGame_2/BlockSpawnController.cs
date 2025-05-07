using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BlockSpawnController : MonoBehaviour
{
    [SerializeField] private GameObject block;
    [SerializeField] private Vector2 offset;
    [SerializeField] private Vector2 pos;

    [SerializeField] private int row; // За
    [SerializeField] private int col; // ї­

    public int blocks;

    private void Start()
    {
        CreateBlocks();
    }

    private void Update()
    {
        if(blocks == 0)
        {
            CreateBlocks();
        }
    }

    private void CreateBlocks()
    {
        for(int i = 0; i < row; i++)
        {
            for (int j = 0; j < col; j++)
            {
                GameObject _block = Instantiate(block, new Vector2(pos.x + (j * offset.x), pos.y +(i* offset.y)), Quaternion.identity);
                _block.transform.parent = transform;
            }
        }

        blocks = this.GetComponentsInChildren<BlockBase>().Length;
    }
}
