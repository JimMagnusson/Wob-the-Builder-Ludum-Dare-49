using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class WinLoseChecker : MonoBehaviour
{
    [SerializeField] UIManager uiManager = null;
    [SerializeField] BlockQueue blockQueue = null;
    [SerializeField] float stabilizationSeconds = 5f;

    private float timeToWin = 0;

    //[SerializeField] private 
    //Currently assume win condition is to place all blocks legally and no block has fallen


    void Start()
    {
        if(blockQueue == null) { Debug.LogError("No reference to blockQueue found"); }
        if (uiManager == null) { Debug.LogError("No reference to uiManager found"); }
        blockQueue.blockQueueEnd += BlockQueue_blockQueueEnd;
    }

    private void BlockQueue_blockQueueEnd()
    {
        // Wait 5 seconds to make sure the buildings are stable
        uiManager.ToggleTimeToWinPopup(true);
        timeToWin = stabilizationSeconds;
    }

    // Update is called once per frame
    void Update()
    {
        if(timeToWin > 0)
        {
            timeToWin -= Time.deltaTime;

            uiManager.UpdateTimeToWinText(timeToWin);

            if (timeToWin <= 0)
            {
                uiManager.ToggleTimeToWinPopup(false);
                Win();
            }
        }
    }

    private void Win()
    {
        uiManager.ToggleWinPopup(true);
    }
    private void Lose()
    {
        uiManager.ToggleLosePopup(true);
    }
}
