using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public delegate void BlockPlacedHandler();

public class Block : MonoBehaviour
{
    public event BlockPlacedHandler BlockPlaced;

    private bool placed = false;

    void Update()
    {
        
    }

    private void OnCollisionEnter(Collision collision)
    {
        if(!placed)
        {
            placed = true;
            if(BlockPlaced != null)
            {
                BlockPlaced();
            }
            GetComponent<Rigidbody>().useGravity = true;
        }
    }
}
