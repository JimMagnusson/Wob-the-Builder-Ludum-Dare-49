using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BlockMover : MonoBehaviour
{
    [SerializeField] private BlockQueue blockQueue = null;
    [SerializeField] private WinLoseChecker winLoseChecker = null;
    //[SerializeField] private 

    [SerializeField] private float airHorizontalSpeed = 10;
    [SerializeField] private float onGroundHorizontalSpeed = 2f;

    [SerializeField] private float fastVerticalSpeed = 10;
    [SerializeField] private float normalVerticalSpeed = 1;

    [SerializeField] private float prePlacedMovementTime = 0.5f;

    private Block currentBlock;
    private Rigidbody currentBlockRB;
    private float horizontalInput;
    private float verticalInput;

    private bool blockPrePlaced = false;
    private float prePlacedTimer = 0;
    private bool moveDownFaster = false;
    private bool gameDone = false;
    private bool stopBlock = false;

    void Start()
    {
        if(blockQueue == null)
        {
            Debug.LogError("No blockQueue reference");
            return;
        }

        if (winLoseChecker == null)
        {
            Debug.LogError("No winLoseChecker reference");
            return;
        }

        winLoseChecker.GameDone += WinLoseChecker_GameDone;

        currentBlock = blockQueue.GetNextBlock();
        if(currentBlock == null)
        {
            Debug.LogError("No block recieved from blockQueue");
            return;
        }

        if (currentBlock == null) { return; }

        currentBlock.BlockPrePlaced += BlockMover_BlockPrePlaced;
        currentBlockRB = currentBlock.GetComponent<Rigidbody>();
    }

    private void WinLoseChecker_GameDone()
    {
        gameDone = true;
    }

    private void BlockMover_BlockPrePlaced()
    {
        // Let the player move the block before placing it.
        {
            blockPrePlaced = true;
            prePlacedTimer = prePlacedMovementTime;
        }
    }

    private void PlaceBlock()
    {
        blockPrePlaced = false;
        currentBlock.GetComponent<Block>().BlockPrePlaced -= BlockMover_BlockPrePlaced;
        currentBlock.SetAsPlaced();
        HandleNewBlock();
    }

    private void HandleNewBlock()
    {
        Block newBlock = blockQueue.GetNextBlock();
        if (newBlock == null)
        {
            currentBlock = null;
            currentBlockRB = null;
        }
        else
        {
            currentBlock = newBlock;
            currentBlock.GetComponent<Block>().BlockPrePlaced += BlockMover_BlockPrePlaced;
            currentBlockRB = currentBlock.GetComponent<Rigidbody>();
        }
    }

    void Update()
    {
        if (gameDone)
        {
            return;
        }

        horizontalInput = Input.GetAxisRaw("Horizontal");
        verticalInput = Input.GetAxisRaw("Vertical");

        if (verticalInput < 0)
        {
            moveDownFaster = true;
        }
        else
        {
            moveDownFaster = false;
        }

        if(blockPrePlaced)
        {
            prePlacedTimer -= Time.deltaTime;

            //If timer is zero or If player holds down, go to placement.
            if (prePlacedTimer <= 0 || verticalInput < 0)
            {
                PlaceBlock();
            }
        }
    }
    private void FixedUpdate()
    {
        if (currentBlockRB == null) { return; }
        if(gameDone)
        {
            currentBlockRB.isKinematic = true;
            return;
        }
        float verticalSpeed = 0;

        if(moveDownFaster)
        {
            verticalSpeed = fastVerticalSpeed;
        }
        else
        {
            verticalSpeed = normalVerticalSpeed;
        }

        float horizontalSpeed = 0;
        // Add player input on x-axis
        if(blockPrePlaced)
        {
            horizontalSpeed = onGroundHorizontalSpeed;
        }
        else
        {
            horizontalSpeed = airHorizontalSpeed;
        }


        currentBlockRB.velocity = new Vector3(horizontalInput * horizontalSpeed, -verticalSpeed, currentBlockRB.velocity.z);
    }
}
