using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class WinLoseChecker : MonoBehaviour
{
    [SerializeField] private Image winPopup;
    [SerializeField] private Image losePopup;

    [SerializeField] private 
    //Currently assume win condition is to place all blocks legally and no block has fallen


    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    private void Win()
    {
        winPopup.enabled = true;
    }
    private void Lose()
    {
        losePopup.enabled = true;
    }
}
