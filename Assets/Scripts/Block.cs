using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public delegate void BlockPlacedHandler();

public class Block : MonoBehaviour
{
    public event BlockPlacedHandler BlockOnGround;

    [SerializeField] PhysicMaterial frictionless;
    [SerializeField] PhysicMaterial general;


    [SerializeField] int startMass = 1;
    [SerializeField] int placedMass = 100;

    private bool onGround = false;
    private Rigidbody rb;
    private Collider generalCollider;

    private void Start()
    {
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

    public void SetAsPlacesd()
    {
        ToggleFriction(true);
        GetComponent<Rigidbody>().useGravity = true;
        rb.mass = placedMass;
        rb.velocity = Vector3.zero;
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
            //GetComponent<Rigidbody>().useGravity = true;
        }
    }
}
