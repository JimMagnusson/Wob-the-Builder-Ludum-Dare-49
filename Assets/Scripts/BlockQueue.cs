using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public delegate void BlockQueueEndHandler();
public class BlockQueue : MonoBehaviour
{
    public event BlockQueueEndHandler blockQueueEnd;
    [SerializeField] BlockSpawner blockSpawner = null;
    [SerializeField] List<BlockType> blockQueue = null;


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
            if(blockQueueEnd != null)
            {
                blockQueueEnd();
            }
        }
        return block;
    }
}
