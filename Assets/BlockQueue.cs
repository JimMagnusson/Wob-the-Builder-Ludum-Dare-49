using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BlockQueue : MonoBehaviour
{
    [SerializeField] List<Block> blockQueue;

    public Block GetNextBlock()
    {
        Block block = null;
        if (blockQueue.Count > 0)
        {
            block = blockQueue[0];
            blockQueue.RemoveAt(0);
        }
        return block;
    }
}
