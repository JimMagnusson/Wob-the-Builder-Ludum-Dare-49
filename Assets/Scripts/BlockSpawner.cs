using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BlockSpawner : MonoBehaviour
{
    [SerializeField] GameObject testhouseFoundation1Prefab = null;
    [SerializeField] GameObject testhouseFloor1Prefab = null;
    [SerializeField] GameObject testhouseRoof1Prefab = null;
    [SerializeField] GameObject testhouseFloor1SmallPrefab = null;

    [SerializeField] GameObject testhouseFoundation2Prefab = null;
    [SerializeField] GameObject testhouseFloor2Prefab = null;
    [SerializeField] GameObject testhouseRoof2Prefab = null;
    [SerializeField] GameObject testhouseFloor2SmallPrefab = null;

    [SerializeField] GameObject testhouseFoundation3Prefab = null;
    [SerializeField] GameObject testhouseFloor3Prefab = null;
    [SerializeField] GameObject testhouseRoof3Prefab = null;
    [SerializeField] GameObject testhouseFloor3SmallPrefab = null;

    [SerializeField] GameObject testhouseFenceSmall = null;
    [SerializeField] GameObject testhouseFenceLarge = null;

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
            case BlockType.testhouse1Foundation:
                if(testhouseFoundation1Prefab == null) { Debug.LogError("Prefab not found"); }
                blockGO = Instantiate(testhouseFoundation1Prefab, spawnpos, testhouseFoundation1Prefab.transform.rotation, blocksParent.transform);
                block = blockGO.GetComponent<Block>();
                if (block == null) { Debug.LogError("No Block component found)"); }
                break;

            case BlockType.testhouse1Floor:
                if (testhouseFloor1Prefab == null) { Debug.LogError("Prefab not found"); }
                blockGO = Instantiate(testhouseFloor1Prefab, spawnpos, testhouseFloor1Prefab.transform.rotation, blocksParent.transform);
                block = blockGO.GetComponent<Block>();
                if (block == null) { Debug.LogError("No Block component found)"); }
                break;

            case BlockType.testHouse1Roof:
                if (testhouseRoof1Prefab == null) { Debug.LogError("Prefab not found"); }
                blockGO = Instantiate(testhouseRoof1Prefab, spawnpos, testhouseRoof1Prefab.transform.rotation, blocksParent.transform);
                block = blockGO.GetComponent<Block>();
                if (block == null) { Debug.LogError("No Block component found)"); }
                break;

            case BlockType.testHouse1FloorSmall:
                if (testhouseFloor1SmallPrefab == null) { Debug.LogError("Prefab not found"); }
                blockGO = Instantiate(testhouseFloor1SmallPrefab, spawnpos, testhouseFloor1SmallPrefab.transform.rotation, blocksParent.transform);
                block = blockGO.GetComponent<Block>();
                if (block == null) { Debug.LogError("No Block component found)"); }
                break;




            case BlockType.testhouse2Foundation:
                if (testhouseFoundation2Prefab == null) { Debug.LogError("Prefab not found"); }
                blockGO = Instantiate(testhouseFoundation2Prefab, spawnpos, testhouseFoundation2Prefab.transform.rotation, blocksParent.transform);
                block = blockGO.GetComponent<Block>();
                if (block == null) { Debug.LogError("No Block component found)"); }
                break;

            case BlockType.testhouse2Floor:
                if (testhouseFloor2Prefab == null) { Debug.LogError("Prefab not found"); }
                blockGO = Instantiate(testhouseFloor2Prefab, spawnpos, testhouseFloor2Prefab.transform.rotation, blocksParent.transform);
                block = blockGO.GetComponent<Block>();
                if (block == null) { Debug.LogError("No Block component found)"); }
                break;

            case BlockType.testHouse2Roof:
                if (testhouseRoof2Prefab == null) { Debug.LogError("Prefab not found"); }
                blockGO = Instantiate(testhouseRoof2Prefab, spawnpos, testhouseRoof2Prefab.transform.rotation, blocksParent.transform);
                block = blockGO.GetComponent<Block>();
                if (block == null) { Debug.LogError("No Block component found)"); }
                break;

            case BlockType.testHouse2FloorSmall:
                if (testhouseFloor2SmallPrefab == null) { Debug.LogError("Prefab not found"); }
                blockGO = Instantiate(testhouseFloor2SmallPrefab, spawnpos, testhouseFloor2SmallPrefab.transform.rotation, blocksParent.transform);
                block = blockGO.GetComponent<Block>();
                if (block == null) { Debug.LogError("No Block component found)"); }
                break;



            case BlockType.testhouse3Foundation:
                if (testhouseFoundation3Prefab == null) { Debug.LogError("Prefab not found"); }
                blockGO = Instantiate(testhouseFoundation3Prefab, spawnpos, testhouseFoundation3Prefab.transform.rotation, blocksParent.transform);
                block = blockGO.GetComponent<Block>();
                if (block == null) { Debug.LogError("No Block component found)"); }
                break;

            case BlockType.testhouse3Floor:
                if (testhouseFloor3Prefab == null) { Debug.LogError("Prefab not found"); }
                blockGO = Instantiate(testhouseFloor3Prefab, spawnpos, testhouseFloor3Prefab.transform.rotation, blocksParent.transform);
                block = blockGO.GetComponent<Block>();
                if (block == null) { Debug.LogError("No Block component found)"); }
                break;

            case BlockType.testHouse3Roof:
                if (testhouseRoof3Prefab == null) { Debug.LogError("Prefab not found"); }
                blockGO = Instantiate(testhouseRoof3Prefab, spawnpos, testhouseRoof3Prefab.transform.rotation, blocksParent.transform);
                block = blockGO.GetComponent<Block>();
                if (block == null) { Debug.LogError("No Block component found)"); }
                break;

            case BlockType.testHouse3FloorSmall:
                if (testhouseFloor3SmallPrefab == null) { Debug.LogError("Prefab not found"); }
                blockGO = Instantiate(testhouseFloor3SmallPrefab, spawnpos, testhouseFloor3SmallPrefab.transform.rotation, blocksParent.transform);
                block = blockGO.GetComponent<Block>();
                if (block == null) { Debug.LogError("No Block component found)"); }
                break;



            case BlockType.testHouseFenceSmall:
                if (testhouseFenceSmall == null) { Debug.LogError("Prefab not found"); }
                blockGO = Instantiate(testhouseFenceSmall, spawnpos, testhouseFenceSmall.transform.rotation, blocksParent.transform);
                block = blockGO.GetComponent<Block>();
                if (block == null) { Debug.LogError("No Block component found)"); }
                break;

            case BlockType.testHouseFenceLarge:
                if (testhouseFenceLarge == null) { Debug.LogError("Prefab not found"); }
                blockGO = Instantiate(testhouseFenceLarge, spawnpos, testhouseFenceLarge.transform.rotation, blocksParent.transform);
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
