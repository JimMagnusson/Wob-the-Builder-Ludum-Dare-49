using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BlockMover : MonoBehaviour
{
    [SerializeField] private Transform currentBlock;
    private Rigidbody currentBlockRB;

    [SerializeField] private float moveSpeed = 2;

    // Start is called before the first frame update
    void Start()
    {
        currentBlockRB = currentBlock.GetComponent<Rigidbody>();
    }

    // Update is called once per frame
    void Update()
    {
        if(currentBlock == null) { return; }

        float horizontalInput = Input.GetAxis("Horizontal");
    }
}
