using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BlockMover : MonoBehaviour
{
    [SerializeField] private BlockQueue blockQueue;


    [SerializeField] private float horizontalSpeed = 2;
    [SerializeField] private float fastVerticalSpeed = 10;
    [SerializeField] private float normalVerticalSpeed = 1;

    [SerializeField] private float groundBaseTime = 0.25f;
    [SerializeField] private float groundMovementTime = 0.75f;

    private Block currentBlock;
    private Rigidbody currentBlockRB;
    private float horizontalInput;

    private bool moveFaster = false;

    // Start is called before the first frame update
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
        StartCoroutine(GroundMovementWait());
    }

    private IEnumerator GroundMovementWait()
    {
        yield return new WaitForSeconds(groundMovementTime);
        currentBlock.GetComponent<Block>().BlockOnGround -= BlockMover_BlockOnGround;
        currentBlock.SetAsPlacesd();
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
