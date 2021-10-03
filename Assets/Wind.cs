using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Wind : MonoBehaviour
{

    [SerializeField] bool directedRight = true;

    [SerializeField] float windStrength = 10f;
    [SerializeField] float windPlacedStrength = 50f;

    public bool IsDirectedRight()
    {
        return directedRight;
    }

    public float GetWindStrength()
    {
        return windStrength;
    }

    public float GetWindPlacedStrength()
    {
        return windPlacedStrength;
    }
}
