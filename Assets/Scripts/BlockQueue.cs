using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public delegate void BlockQueueEndHandler();

public delegate void BlockHasFallenHandler();

public class BlockQueue : MonoBehaviour
{
    public event BlockQueueEndHandler BlockQueueEnd;
    public event BlockHasFallenHandler BlockHasFallen;

    [SerializeField] BlockSpawner blockSpawner = null;
    [SerializeField] UIManager uiManager = null;
    [SerializeField] int numberOfBlocksInUI = 3;
    [SerializeField] List<BlockType> blockQueue = null;


    private void Start()
    {
        UpdateBlockQueueUI();
    }

    private void UpdateBlockQueueUI()
    {
        if (uiManager == null) { Debug.LogError("No ref to uiManager"); }
        for (int i = 0; i < numberOfBlocksInUI; i++)
        {
            BlockType blockType = BlockType.none;
            if(i < blockQueue.Count)
            {
                blockType = blockQueue[i];
            }
            uiManager.UpdateBlocksUI(i, blockType);
        }

        uiManager.UpdateBlocksLeftText(blockQueue.Count);
    }

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

            // Subscribe to lose event:
            block.BlockFallen += Block_BlockFallen;
            UpdateBlockQueueUI();
        }
        else
        {
            BlockQueueEnd?.Invoke();
        }
        return block;
    }

    private void Block_BlockFallen()
    {
        BlockHasFallen?.Invoke();
    }
}
