using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;


public delegate void GameDoneHandler();

public class WinLoseChecker : MonoBehaviour
{
    [SerializeField] private UIManager uiManager = null;
    [SerializeField] private BlockQueue blockQueue = null;
    //[SerializeField] private GameManager gameManager = null;
    [SerializeField] private float stabilizationSeconds = 4f;

    public event GameDoneHandler GameDone;
    private float timeToWin = 0;
    private bool hasLostOrWon = false;

    void Start()
    {
        if(blockQueue == null) { Debug.LogError("No reference to blockQueue found"); }
        if (uiManager == null) { Debug.LogError("No reference to uiManager found"); }
        //if (gameManager == null) { Debug.LogError("No reference to gameManager found"); }
        blockQueue.BlockQueueEnd += BlockQueue_blockQueueEnd;
        blockQueue.BlockHasFallen += BlockQueue_blockHasFallen;
    }

    private void BlockQueue_blockHasFallen()
    {
        if(!hasLostOrWon)
        {
            hasLostOrWon = true;
            Lose();
        }
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

                
                if (!hasLostOrWon)
                {
                    hasLostOrWon = true;
                    Win();
                }
            }
        }
    }

    private void Win()
    {
        uiManager.ToggleWinPopup(true);
        GameDone?.Invoke();

    }
    private void Lose()
    {
        // Stop blocks from being able to move.
        uiManager.ToggleLosePopup(true);
        GameDone?.Invoke();
    }
}
