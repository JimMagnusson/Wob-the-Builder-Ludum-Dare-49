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

    [SerializeField] private Sprite testhouseFoundation;
    [SerializeField] private Sprite testhouseFloor;
    [SerializeField] private Sprite testhouseRoof;

    [SerializeField] private Sprite greekFloorBig;
    [SerializeField] private Sprite greekFloorBigAndWide;
    [SerializeField] private Sprite greekFloorPillars;
    [SerializeField] private Sprite greekFoundation;
    [SerializeField] private Sprite greekRoof;
    [SerializeField] private Sprite greekRoofTiny;

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
            case BlockType.testhouseFoundation:
                blockUI.border.sprite = foundationBorder;
                blockUI.levelIcon.sprite = foundationIcon;
                //blockUI.levelIcon.image = testhouseFoundation;
                break;
            case BlockType.testhouseFloor:
                blockUI.border.sprite = floorBorder;
                blockUI.levelIcon.sprite = floorIcon;
                //blockUI.levelIcon.image = testhouseFloor;
                break;
            case BlockType.testHouseRoof:
                blockUI.border.sprite = roofBorder;
                blockUI.levelIcon.sprite = roofIcon;
                //blockUI.levelIcon.image = testhouseRoof;
                break;
            case BlockType.greekFloorBig:
                blockUI.border.sprite = floorBorder;
                blockUI.levelIcon.sprite = floorIcon;
                //blockUI.levelIcon.image = greekFloorBig;
                break;
            case BlockType.greekFloorBigAndWide:
                blockUI.border.sprite = floorBorder;
                blockUI.levelIcon.sprite = floorIcon;
                //blockUI.levelIcon.image = greekFloorBigAndWide;
                break;
            case BlockType.greekFloorPillars:
                blockUI.border.sprite = floorBorder;
                blockUI.levelIcon.sprite = floorIcon;
                //blockUI.levelIcon.image = greekFloorPillars;
                break;
            case BlockType.greekFoundation:
                blockUI.border.sprite = foundationBorder;
                blockUI.levelIcon.sprite = foundationIcon;
                //blockUI.levelIcon.image = greekFoundation;
                break;
            case BlockType.greekRoof:
                blockUI.border.sprite = roofBorder;
                blockUI.levelIcon.sprite = roofIcon;
                //blockUI.levelIcon.image = greekRoof;
                break;
            case BlockType.greekRoofTiny:
                blockUI.border.sprite = roofBorder;
                blockUI.levelIcon.sprite = roofIcon;
                //blockUI.levelIcon.image = greekRoofTiny;
                break;
        }
    }

    public void UpdateBlocksLeftText(int blocksLeft)
    {
        blocksLeftText.text = blocksLeftString + blocksLeft;
    }
}
