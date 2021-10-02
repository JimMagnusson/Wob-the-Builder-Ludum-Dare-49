using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public delegate void BlockQueueEmptyHandler();
public class BlockQueue : MonoBehaviour
{
    public event BlockQueueEmptyHandler blockQueueEmpty;
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
        else
        {
            Debug.Log("End of block queue");
            if(blockQueueEmpty != null)
            {
                blockQueueEmpty();
            }
        }
        return block;
    }
}
