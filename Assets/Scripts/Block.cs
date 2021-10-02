using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public delegate void BlockOnGroundHandler();

public class Block : MonoBehaviour
{
    public event BlockOnGroundHandler BlockOnGround;
    public bool Placed { get; private set; }

    [SerializeField] PhysicMaterial frictionless;
    [SerializeField] PhysicMaterial general;


    [SerializeField] int startMass = 1;
    [SerializeField] int placedMass = 100;

    private bool onGround = false;
    private Rigidbody rb;
    private Collider generalCollider;

    private void Start()
    {
        Placed = false;
        rb = GetComponent<Rigidbody>();
        generalCollider = GetComponent<Collider>();

        rb.mass = startMass;
        ToggleFriction(false);
    }


    private void ToggleFriction(bool activate)
    {
        if(frictionless == null || general == null) { Debug.LogError("No physics friction materials reference found. Check PhysicMaterial fields."); }
        if(activate)
        {
            generalCollider.material = general;
        }
        else
        {
            generalCollider.material = frictionless;
        }
    }

    public void SetAsPlaced()
    {
        ToggleFriction(true);
        GetComponent<Rigidbody>().useGravity = true;
        rb.mass = placedMass;
        rb.velocity = Vector3.zero;
        Placed = true;
    }

    private void OnCollisionEnter(Collision collision)
    {
        if(!onGround)
        {
            onGround = true;

            // Open constraints
            //rb.constraints = RigidbodyConstraints.FreezeAll;


            if (BlockOnGround != null)
            {
                BlockOnGround();
            }
        }
    }
}
