using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BlockSpawner : MonoBehaviour
{
    [SerializeField] GameObject foundationPrefab = null;
    [SerializeField] GameObject floorPrefab = null;
    [SerializeField] GameObject roofPrefab = null;

    [SerializeField] GameObject blocksParent = null;
    [SerializeField] Transform blockSpawnPosition = null;

    [SerializeField] float randomXMaxDiff = 1f;


    public Block SpawnBlock(BlockType blockType)
    {
        if(blockSpawnPosition == null) { Debug.LogError("No blockSpawnPosition reference"); }
        Block block = null;
        GameObject blockGO = null;

        float randomDiff = Random.Range(-randomXMaxDiff, randomXMaxDiff);
        Vector3 spawnpos = new Vector3(blockSpawnPosition.position.x + randomDiff, blockSpawnPosition.position.y, blockSpawnPosition.position.z);

        switch (blockType)
        {
            case BlockType.foundation:
                if(foundationPrefab == null) { Debug.LogError("Foundation prefab not found"); }
                blockGO = Instantiate(foundationPrefab, spawnpos, foundationPrefab.transform.rotation, blocksParent.transform);
                block = blockGO.GetComponent<Block>();
                if (block == null) { Debug.LogError("No Block component found on Foundation prefab"); }
                break;

            case BlockType.floor:
                if (roofPrefab == null) { Debug.LogError("Roof prefab not found"); }
                blockGO = Instantiate(floorPrefab, spawnpos, floorPrefab.transform.rotation, blocksParent.transform);
                block = blockGO.GetComponent<Block>();
                if (block == null) { Debug.LogError("No Block component found on Floor prefab"); }
                break;

            case BlockType.roof:
                if (roofPrefab == null) { Debug.LogError("Roof prefab not found"); }
                blockGO = Instantiate(roofPrefab, spawnpos, roofPrefab.transform.rotation, blocksParent.transform);
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
