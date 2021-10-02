using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BlockMover : MonoBehaviour
{
    [SerializeField] private BlockQueue blockQueue;
    //[SerializeField] private 

    [SerializeField] private float airHorizontalSpeed = 10;
    [SerializeField] private float onGroundhorizontalSpeed = 2f;

    [SerializeField] private float fastVerticalSpeed = 10;
    [SerializeField] private float normalVerticalSpeed = 1;

    [SerializeField] private float groundMovementTime = 0.5f;

    private Block currentBlock;
    private Rigidbody currentBlockRB;
    private float horizontalInput;
    private float verticalInput;

    private bool blockOnGround = false;
    private float onGroundTimer = 0;
    private bool moveDownFaster = false;

    void Start()
    {
        if(blockQueue == null)
        {
            Debug.LogError("No blockQueue reference");
            return;
        }
        currentBlock = blockQueue.GetNextBlock();
        if(currentBlock == null)
        {
            Debug.LogError("No block recieved from blockQueue");
            return;
        }

        if (currentBlock == null) { return; }

        currentBlock.BlockOnGround += BlockMover_BlockOnGround;
        currentBlockRB = currentBlock.GetComponent<Rigidbody>();
    }

    private void BlockMover_BlockOnGround()
    {
        // Let the player move the block on the ground.
        {
            blockOnGround = true;
            onGroundTimer = groundMovementTime;
        }
    }

    private void PlaceBlock()
    {
        blockOnGround = false;
        currentBlock.GetComponent<Block>().BlockOnGround -= BlockMover_BlockOnGround;
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
            currentBlock.GetComponent<Block>().BlockOnGround += BlockMover_BlockOnGround;
            currentBlockRB = currentBlock.GetComponent<Rigidbody>();
        }
    }

    void Update()
    {
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

        if(blockOnGround)
        {
            onGroundTimer -= Time.deltaTime;

            //If timer is zero or If player holds down, go to placement.
            if (onGroundTimer <= 0 || verticalInput < 0)
            {
                PlaceBlock();
            }
        }
    }
    private void FixedUpdate()
    {
        if (currentBlockRB == null) { return; }
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
        if(blockOnGround)
        {
            horizontalSpeed = onGroundhorizontalSpeed;
        }
        else
        {
            horizontalSpeed = airHorizontalSpeed;
        }


        currentBlockRB.velocity = new Vector3(horizontalInput * horizontalSpeed, -verticalSpeed, currentBlockRB.velocity.z);
    }
}
