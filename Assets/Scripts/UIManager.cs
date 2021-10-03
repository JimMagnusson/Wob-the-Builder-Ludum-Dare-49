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
    [SerializeField] private Sprite roofBorder = null;
    [SerializeField] private Sprite floorBorder = null;
    [SerializeField] private Sprite foundationBorder = null;

    [SerializeField] private Sprite roofIcon = null;
    [SerializeField] private Sprite floorIcon = null;
    [SerializeField] private Sprite foundationIcon = null;

    [SerializeField] private Sprite testhouseFoundation = null;
    [SerializeField] private Sprite testhouseFloor = null;
    [SerializeField] private Sprite testhouseRoof = null;

    [SerializeField] private Sprite greekFloorBig = null;
    [SerializeField] private Sprite greekFloorBigAndWide = null;
    [SerializeField] private Sprite greekFloorPillars = null;
    [SerializeField] private Sprite greekFoundation = null;
    [SerializeField] private Sprite greekRoof = null;
    [SerializeField] private Sprite greekRoofTiny = null;

    [SerializeField] private Sprite mountainFloorLarge = null;
    [SerializeField] private Sprite mountainFloorSmall = null;
    [SerializeField] private Sprite mountainFoundationLarge = null;
    [SerializeField] private Sprite mountainFoundationSmall = null;
    [SerializeField] private Sprite mountainRoofLarge = null;
    [SerializeField] private Sprite mountainRoofSmall = null;


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
            case BlockType.mountainFloorLarge:
                blockUI.border.sprite = floorBorder;
                blockUI.levelIcon.sprite = floorIcon;
                //blockUI.levelIcon.image = mountainFloorLarge;
                break;
            case BlockType.mountainFloorSmall:
                blockUI.border.sprite = floorBorder;
                blockUI.levelIcon.sprite = floorIcon;
                //blockUI.levelIcon.image = mountainFloorSmall;
                break;
            case BlockType.mountainFoundationLarge:
                blockUI.border.sprite = floorBorder;
                blockUI.levelIcon.sprite = floorIcon;
                //blockUI.levelIcon.image = mountainFoundationLarge;
                break;
            case BlockType.mountainFoundationSmall:
                blockUI.border.sprite = floorBorder;
                blockUI.levelIcon.sprite = floorIcon;
                //blockUI.levelIcon.image = mountainFoundationSmall;
                break;
            case BlockType.mountainRoofLarge:
                blockUI.border.sprite = floorBorder;
                blockUI.levelIcon.sprite = floorIcon;
                //blockUI.levelIcon.image = mountainRoofLarge;
                break;
            case BlockType.mountainRoofSmall:
                blockUI.border.sprite = floorBorder;
                blockUI.levelIcon.sprite = floorIcon;
                //blockUI.levelIcon.image = mountainRoofSmall;
                break;
        }
    }

    public void UpdateBlocksLeftText(int blocksLeft)
    {
        blocksLeftText.text = blocksLeftString + blocksLeft;
    }
}
