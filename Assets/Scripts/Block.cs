using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public delegate void BlockPrePlacedHandler();
public delegate void BlockFallenHandler();

public class Block : MonoBehaviour
{
    public event BlockPrePlacedHandler BlockPrePlaced;
    public event BlockFallenHandler BlockFallen;
    public bool Placed { get; private set; }

    [SerializeField] private PhysicMaterial frictionless = null;
    [SerializeField] private PhysicMaterial general = null;


    [SerializeField] private int startMass = 1;
    [SerializeField] private int placedMass = 20;

    [SerializeField] private BlockLevelType blockLevelType = BlockLevelType.none;
    [SerializeField] AudioClip blockPlacedSFX1 = null;
    [SerializeField] AudioClip blockPlacedSFX2 = null;
    [SerializeField] AudioClip destroyedSFX1 = null;
    [SerializeField] AudioClip destroyedSFX2 = null;

    private bool hasBeenPrePlaced = false;
    private Rigidbody rb;
    private Collider generalCollider;
    private Wind wind = null;
    private AudioSource audioSource;


    private void Start()
    {
        Placed = false;
        wind = FindObjectOfType<Wind>();
        rb = GetComponent<Rigidbody>();
        audioSource = GetComponent<AudioSource>();
        generalCollider = GetComponent<Collider>();

        rb.mass = startMass;
        ToggleFriction(false);
        rb.constraints = RigidbodyConstraints.FreezePositionZ;

    }

    public BlockLevelType GetBlockLevelType()
    {
        return blockLevelType;
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

    private void OnTriggerEnter(Collider other)
    {
        if(other.CompareTag("BoundingBox"))
        {
            Debug.Log("Block has fallen out of bounds. Lose game");
            BlockFallen?.Invoke();
        }
    }

    private void PlayDestroyedSFX()
    {
        if (FindObjectOfType<GameManager>().IsGameMuted()) { return; }
        int randomNum = Random.Range(0, 2);
        if (randomNum == 0)
        {
            audioSource.PlayOneShot(destroyedSFX1);
        }
        else
        {
            audioSource.PlayOneShot(destroyedSFX2);
        }
    }

    private void PlayPlacedSFX()
    {
        if (FindObjectOfType<GameManager>().IsGameMuted()) { return; }
        int randomNum = Random.Range(0, 2);
        if (randomNum == 0)
        {
            audioSource.PlayOneShot(blockPlacedSFX1);
        }
        else
        {
            audioSource.PlayOneShot(blockPlacedSFX2);
        }
        hasBeenPrePlaced = true;
    }

    private void OnCollisionEnter(Collision collision)
    {
        Block collidingBlock = collision.gameObject.GetComponent<Block>();

        switch (blockLevelType)
        {
            case BlockLevelType.none:
                Debug.LogError("Block level type is marked as none. Check the inspector value.");
                break;
            case BlockLevelType.foundation:

                break;
            case BlockLevelType.floor:
                // Lose if floor block is placed on ground
                if (collision.gameObject.CompareTag("Ground"))
                {
                    Debug.Log("Floor block placed on ground surface. Lose game");
                    PlayDestroyedSFX();
                    BlockFallen?.Invoke();
                }
                break;
            case BlockLevelType.roof:
                // Lose if roof block is placed on ground
                if (collision.gameObject.CompareTag("Ground"))
                {
                    Debug.Log("Floor block placed on ground surface. Lose game");
                    PlayDestroyedSFX();
                    BlockFallen?.Invoke();
                }
                break;
            default:
                Debug.LogError("Unknown block level type: " + blockLevelType + ". Check the inspector value.");
                break;
        }
        if (!hasBeenPrePlaced)
        {
            PlayPlacedSFX();
            // Open constraints
            rb.constraints = RigidbodyConstraints.None;

            BlockPrePlaced?.Invoke();
        }
    }

    private void FixedUpdate()
    {
        if(wind != null)
        {
            float strength = 0f;
            if(Placed)
            {
                strength = wind.GetWindPlacedStrength();
            }
            else
            {
                strength = wind.GetWindStrength();
            }

            // Apply wind
            if (wind.IsDirectedRight())
            {
                rb.AddForce(Vector3.right * strength);
            }
            else
            {
                rb.AddForce(-Vector3.right * strength);
            }
        }
    }
}
