using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BlockSpawner : MonoBehaviour
{
    [SerializeField] GameObject testhouseFoundationPrefab = null;
    [SerializeField] GameObject testhouseFloorPrefab = null;
    [SerializeField] GameObject testhouseRoofPrefab = null;

    [SerializeField] GameObject greekFloorBigPrefab = null;
    [SerializeField] GameObject greekFloorBigAndWidePrefab = null;
    [SerializeField] GameObject greekFloorPillarsPrefab = null;
    [SerializeField] GameObject greekFoundationPrefab = null;
    [SerializeField] GameObject greekRoofPrefab = null;
    [SerializeField] GameObject greekRoofTinyPrefab = null;

    [SerializeField] GameObject mountainFloorLargePrefab = null;
    [SerializeField] GameObject mountainFloorSmallPrefab = null;
    [SerializeField] GameObject mountainFoundationLargePrefab = null;
    [SerializeField] GameObject mountainFoundationSmallPrefab = null;
    [SerializeField] GameObject mountainRoofLargePrefab = null;
    [SerializeField] GameObject mountainRoofSmallPrefab = null;

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
            case BlockType.testhouseFoundation:
                if(testhouseFoundationPrefab == null) { Debug.LogError("Prefab not found"); }
                blockGO = Instantiate(testhouseFoundationPrefab, spawnpos, testhouseFoundationPrefab.transform.rotation, blocksParent.transform);
                block = blockGO.GetComponent<Block>();
                if (block == null) { Debug.LogError("No Block component found)"); }
                break;

            case BlockType.testhouseFloor:
                if (testhouseFloorPrefab == null) { Debug.LogError("Prefab not found"); }
                blockGO = Instantiate(testhouseFloorPrefab, spawnpos, testhouseFloorPrefab.transform.rotation, blocksParent.transform);
                block = blockGO.GetComponent<Block>();
                if (block == null) { Debug.LogError("No Block component found)"); }
                break;

            case BlockType.testHouseRoof:
                if (testhouseRoofPrefab == null) { Debug.LogError("Prefab not found"); }
                blockGO = Instantiate(testhouseRoofPrefab, spawnpos, testhouseRoofPrefab.transform.rotation, blocksParent.transform);
                block = blockGO.GetComponent<Block>();
                if (block == null) { Debug.LogError("No Block component found)"); }
                break;

            case BlockType.greekFloorBig:
                if (greekFloorBigPrefab == null) { Debug.LogError("Prefab not found"); }
                blockGO = Instantiate(greekFloorBigPrefab, spawnpos, greekFloorBigPrefab.transform.rotation, blocksParent.transform);
                block = blockGO.GetComponent<Block>();
                if (block == null) { Debug.LogError("No Block component found)"); }
                break;

            case BlockType.greekFloorBigAndWide:
                if (greekFloorBigAndWidePrefab == null) { Debug.LogError("Prefab not found"); }
                blockGO = Instantiate(greekFloorBigAndWidePrefab, spawnpos, greekFloorBigAndWidePrefab.transform.rotation, blocksParent.transform);
                block = blockGO.GetComponent<Block>();
                if (block == null) { Debug.LogError("No Block component found)"); }
                break;

            case BlockType.greekFloorPillars:
                if (greekFloorPillarsPrefab == null) { Debug.LogError("Prefab not found"); }
                blockGO = Instantiate(greekFloorPillarsPrefab, spawnpos, greekFloorPillarsPrefab.transform.rotation, blocksParent.transform);
                block = blockGO.GetComponent<Block>();
                if (block == null) { Debug.LogError("No Block component found)"); }
                break;

            case BlockType.greekFoundation:
                if (greekFloorPillarsPrefab == null) { Debug.LogError("Prefab not found"); }
                blockGO = Instantiate(greekFoundationPrefab, spawnpos, greekFoundationPrefab.transform.rotation, blocksParent.transform);
                block = blockGO.GetComponent<Block>();
                if (block == null) { Debug.LogError("No Block component found)"); }
                break;

            case BlockType.greekRoof:
                if (greekRoofPrefab == null) { Debug.LogError("Prefab not found"); }
                blockGO = Instantiate(greekRoofPrefab, spawnpos, greekRoofPrefab.transform.rotation, blocksParent.transform);
                block = blockGO.GetComponent<Block>();
                if (block == null) { Debug.LogError("No Block component found)"); }
                break;

            case BlockType.greekRoofTiny:
                if (greekRoofTinyPrefab == null) { Debug.LogError("Prefab not found"); }
                blockGO = Instantiate(greekRoofTinyPrefab, spawnpos, greekRoofTinyPrefab.transform.rotation, blocksParent.transform);
                block = blockGO.GetComponent<Block>();
                if (block == null) { Debug.LogError("No Block component found)"); }
                break;

            case BlockType.mountainFloorLarge:
                if (mountainFloorLargePrefab == null) { Debug.LogError("Prefab not found"); }
                blockGO = Instantiate(mountainFloorLargePrefab, spawnpos, mountainFloorLargePrefab.transform.rotation, blocksParent.transform);
                block = blockGO.GetComponent<Block>();
                if (block == null) { Debug.LogError("No Block component found)"); }
                break;

            case BlockType.mountainFloorSmall:
                if (mountainFloorSmallPrefab == null) { Debug.LogError("Prefab not found"); }
                blockGO = Instantiate(mountainFloorSmallPrefab, spawnpos, mountainFloorSmallPrefab.transform.rotation, blocksParent.transform);
                block = blockGO.GetComponent<Block>();
                if (block == null) { Debug.LogError("No Block component found)"); }
                break;

            case BlockType.mountainFoundationLarge:
                if (mountainFoundationLargePrefab == null) { Debug.LogError("Prefab not found"); }
                blockGO = Instantiate(mountainFoundationLargePrefab, spawnpos, mountainFoundationLargePrefab.transform.rotation, blocksParent.transform);
                block = blockGO.GetComponent<Block>();
                if (block == null) { Debug.LogError("No Block component found)"); }
                break;

            case BlockType.mountainFoundationSmall:
                if (mountainFoundationSmallPrefab == null) { Debug.LogError("Prefab not found"); }
                blockGO = Instantiate(mountainFoundationSmallPrefab, spawnpos, mountainFoundationSmallPrefab.transform.rotation, blocksParent.transform);
                block = blockGO.GetComponent<Block>();
                if (block == null) { Debug.LogError("No Block component found)"); }
                break;

            case BlockType.mountainRoofLarge:
                if (mountainRoofLargePrefab == null) { Debug.LogError("Prefab not found"); }
                blockGO = Instantiate(mountainRoofLargePrefab, spawnpos, mountainRoofLargePrefab.transform.rotation, blocksParent.transform);
                block = blockGO.GetComponent<Block>();
                if (block == null) { Debug.LogError("No Block component found)"); }
                break;

            case BlockType.mountainRoofSmall:
                if (mountainRoofSmallPrefab == null) { Debug.LogError("Prefab not found"); }
                blockGO = Instantiate(mountainRoofSmallPrefab, spawnpos, mountainRoofSmallPrefab.transform.rotation, blocksParent.transform);
                block = blockGO.GetComponent<Block>();
                if (block == null) { Debug.LogError("No Block component found)"); }
                break;

            default:
                Debug.LogError("No case for the block type: " + blockType);
                break;
        }
        return block;
    }
}
