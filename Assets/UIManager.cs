using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class UIManager : MonoBehaviour
{
    [SerializeField] private Image winPopup = null;
    [SerializeField] private Image losePopup = null;
    [SerializeField] private Image timeToWinPopup = null;
    [SerializeField] private TextMeshProUGUI timeToWinText = null;

    [SerializeField] private BlockUI[] blockUIs = null;
    [SerializeField] private Sprite roofBorder;
    [SerializeField] private Sprite floorBorder;
    [SerializeField] private Sprite foundationBorder;

    [SerializeField] private Sprite roofIcon;
    [SerializeField] private Sprite floorIcon;
    [SerializeField] private Sprite foundationIcon;

    [SerializeField] private TextMeshProUGUI blocksLeftText = null;

    private string timeToWinString;
    private string blocksLeftString;

    private void Awake()
    {
        if (timeToWinText == null) { Debug.LogError("blocksLeftText no reference found."); }
        blocksLeftString = blocksLeftText.text;
    }

    private void Start()
    {
        if (timeToWinText == null) { Debug.LogError("Time to win text no reference found."); }
    }

    public void ToggleTimeToWinPopup(bool toggle)
    {
        timeToWinPopup.gameObject.SetActive(toggle);
    }

    public void ToggleWinPopup(bool toggle)
    {
        winPopup.gameObject.SetActive(toggle);
    }

    public void ToggleLosePopup(bool toggle)
    {
        losePopup.gameObject.SetActive(toggle);
    }

    public void UpdateTimeToWinText(float timeToWin)
    {
        timeToWinString = ((int)(timeToWin + 1)).ToString();
        timeToWinText.text = timeToWinString;

        // Edit transparancy based on how close to next second it is.
        float diff = timeToWin - (int)timeToWin;
        timeToWinText.alpha = diff / 1f;
    }

    public void UpdateBlocksUI(int index, BlockType blockType)
    {
        if(index < 0 || index >= blockUIs.Length) { Debug.LogError("Invalid index för blocksUI array: " + index); }
        BlockUI blockUI = blockUIs[index];
        if(blockUI == null) { Debug.LogError("No BlockUI reference. Check BlockUIs array in UIManager"); }
        blockUI.gameObject.SetActive(true);
        switch (blockType)
        {
            case BlockType.none:
                blockUI.gameObject.SetActive(false);
                break;
            case BlockType.foundation:
                blockUI.border.sprite = foundationBorder;
                blockUI.levelIcon.sprite = foundationIcon;
                break;
            case BlockType.floor:
                blockUI.border.sprite = floorBorder;
                blockUI.levelIcon.sprite = floorIcon;
                break;
            case BlockType.roof:
                blockUI.border.sprite = roofBorder;
                blockUI.levelIcon.sprite = roofIcon;
                break;
        }
    }

    public void UpdateBlocksLeftText(int blocksLeft)
    {
        blocksLeftText.text = blocksLeftString + blocksLeft;
    }
}
