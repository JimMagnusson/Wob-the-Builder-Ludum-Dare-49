using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BlockSpawner : MonoBehaviour
{
    [SerializeField] GameObject foundationPrefab;
    [SerializeField] GameObject roofPrefab;

    [SerializeField] GameObject blocksParent;
    [SerializeField] Transform blockSpawnPosition;


    public Block SpawnBlock(BlockType blockType)
    {
        if(blockSpawnPosition == null) { Debug.LogError("No blockSpawnPosition reference"); }
        Block block = null;
        GameObject blockGO = null;

        switch (blockType)
        {
            case BlockType.foundation:
                if(foundationPrefab == null) { Debug.LogError("Foundation prefab not found"); }
                blockGO = Instantiate(foundationPrefab, blockSpawnPosition.position, foundationPrefab.transform.rotation, blocksParent.transform);
                block = blockGO.GetComponent<Block>();
                if (block == null) { Debug.LogError("No Block component found on Foundation prefab"); }
                break;
            case BlockType.roof:
                if (roofPrefab == null) { Debug.LogError("Roof prefab not found"); }
                blockGO = Instantiate(roofPrefab, blockSpawnPosition.position, roofPrefab.transform.rotation, blocksParent.transform);
                block = blockGO.GetComponent<Block>();
                if (block == null) { Debug.LogError("No Block component found on Foundation prefab"); }
                break;
            default:
                Debug.LogError("No case for the block type: " + blockType);
                break;
        }
        return block;
    }
}
