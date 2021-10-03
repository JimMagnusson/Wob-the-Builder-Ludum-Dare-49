using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Wind : MonoBehaviour
{

    [SerializeField] bool directedRight = true;

    [SerializeField] float windStrength = 50f;

    public bool IsDirectedRight()
    {
        return directedRight;
    }

    public float GetWindStrength()
    {
        return windStrength;
    }



    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
