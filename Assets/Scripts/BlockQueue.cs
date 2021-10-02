using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BlockQueue : MonoBehaviour
{
    [SerializeField] BlockSpawner blockSpawner;

    [SerializeField] List<BlockType> blockQueue;



    public Block GetNextBlock()
    {
        if(blockSpawner == null)
        {
            Debug.LogError("No blockSpawner reference");
            return null;
        }

        Block block = null;
        if (blockQueue.Count > 0)
        {
            BlockType blockType = blockQueue[0];
            blockQueue.RemoveAt(0);
            block = blockSpawner.SpawnBlock(blockType);
        }
        return block;
    }
}
