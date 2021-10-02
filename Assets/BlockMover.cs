using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BlockMover : MonoBehaviour
{
    [SerializeField] private Transform currentBlock;
    [SerializeField] private BlockQueue blockQueue;


    [SerializeField] private float horizontalSpeed = 2;
    [SerializeField] private float fastVerticalSpeed = 10;
    [SerializeField] private float normalVerticalSpeed = 1;


    private Rigidbody currentBlockRB;
    private float horizontalInput;

    private bool moveFaster = false;

    // Start is called before the first frame update
    void Start()
    {
        currentBlock = blockQueue.GetNextBlock().transform;
        if (currentBlock == null) { return; }
        currentBlock.GetComponent<Block>().BlockPlaced += BlockMover_BlockPlaced;
        currentBlockRB = currentBlock.GetComponent<Rigidbody>();
    }

    private void BlockMover_BlockPlaced()
    {
        currentBlock.GetComponent<Block>().BlockPlaced -= BlockMover_BlockPlaced;
        Block newBlock = blockQueue.GetNextBlock();
        if(newBlock == null)
        {
            currentBlock = null;
            currentBlockRB = null;
        }
        else
        {
            currentBlock = newBlock.transform;
            currentBlock.GetComponent<Block>().BlockPlaced += BlockMover_BlockPlaced;
            currentBlockRB = currentBlock.GetComponent<Rigidbody>();
        }
    }

    // Update is called once per frame
    void Update()
    {

        horizontalInput = Input.GetAxisRaw("Horizontal");
        if(Input.GetAxisRaw("Vertical") < 0)
        {
            moveFaster = true;
        }
        else
        {
            moveFaster = false;
        }
    }

    private void FixedUpdate()
    {
        if (currentBlockRB == null) { return; }
        float verticalSpeed = 0;

        if(moveFaster)
        {
            verticalSpeed = fastVerticalSpeed;
        }
        else
        {
            verticalSpeed = normalVerticalSpeed;
        }

        // Add player input on x-axis
        currentBlockRB.velocity = new Vector3(horizontalInput * horizontalSpeed, -verticalSpeed, currentBlockRB.velocity.z);
    }
}
