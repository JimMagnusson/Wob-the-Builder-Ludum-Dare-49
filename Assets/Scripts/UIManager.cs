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

    [SerializeField] private Sprite testhouse1Foundation = null;
    [SerializeField] private Sprite testhouse1Floor = null;
    [SerializeField] private Sprite testhouse1Roof = null;
    [SerializeField] private Sprite testhouse1FloorSmall = null;

    [SerializeField] private Sprite testhouse2Foundation = null;
    [SerializeField] private Sprite testhouse2Floor = null;
    [SerializeField] private Sprite testhouse2Roof = null;
    [SerializeField] private Sprite testhouse2FloorSmall = null;

    [SerializeField] private Sprite testhouse3Foundation = null;
    [SerializeField] private Sprite testhouse3Floor = null;
    [SerializeField] private Sprite testhouse3Roof = null;
    [SerializeField] private Sprite testhouse3FloorSmall = null;

    [SerializeField] private Sprite testhouseFenceSmall = null;
    [SerializeField] private Sprite testhouseFenceLarge = null;

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

    [SerializeField] private Image windIcon = null;
    [SerializeField] private Sprite weakWindSprite = null;
    [SerializeField] private Sprite strongWindSprite = null;
    [SerializeField] private int switchIconAtPlacedWindStrength = 75;

    private string timeToWinString;
    private string blocksLeftString;
    private Wind wind;

    private void Awake()
    {
        if (timeToWinText == null) { Debug.LogError("blocksLeftText no reference found."); }
        blocksLeftString = blocksLeftText.text;
    }

    private void Start()
    {
        if (timeToWinText == null) { Debug.LogError("Time to win text no reference found."); }
        wind = FindObjectOfType<Wind>();
        if (wind != null)
        {
            windIcon.transform.parent.gameObject.SetActive(true);
            if (wind.GetWindPlacedStrength() < switchIconAtPlacedWindStrength)
            {
                windIcon.sprite = weakWindSprite;
            }
            else
            {
                windIcon.sprite = strongWindSprite;
            }

            if(!wind.IsDirectedRight()) {
                Vector3 tempLocalScale = windIcon.GetComponent<RectTransform>().localScale;
                windIcon.GetComponent<RectTransform>().localScale = new Vector3(-tempLocalScale.x, tempLocalScale.y, tempLocalScale.z);
            }
        }
        else
        {
            windIcon.transform.parent.gameObject.SetActive(false);
        }
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
            case BlockType.testhouse1Foundation:
                blockUI.border.sprite = foundationBorder;
                blockUI.levelIcon.sprite = foundationIcon;
                blockUI.image.sprite = testhouse1Foundation;
                break;
            case BlockType.testhouse1Floor:
                blockUI.border.sprite = floorBorder;
                blockUI.levelIcon.sprite = floorIcon;
                blockUI.image.sprite = testhouse1Floor;
                break;
            case BlockType.testHouse1Roof:
                blockUI.border.sprite = roofBorder;
                blockUI.levelIcon.sprite = roofIcon;
                blockUI.image.sprite = testhouse1Roof;
                break;
            case BlockType.testHouse1FloorSmall:
                blockUI.border.sprite = floorBorder;
                blockUI.levelIcon.sprite = floorIcon;
                blockUI.image.sprite = testhouse1FloorSmall;
                break;

            case BlockType.testhouse2Foundation:
                blockUI.border.sprite = foundationBorder;
                blockUI.levelIcon.sprite = foundationIcon;
                blockUI.image.sprite = testhouse2Foundation;
                break;
            case BlockType.testhouse2Floor:
                blockUI.border.sprite = floorBorder;
                blockUI.levelIcon.sprite = floorIcon;
                blockUI.image.sprite = testhouse2Floor;
                break;
            case BlockType.testHouse2Roof:
                blockUI.border.sprite = roofBorder;
                blockUI.levelIcon.sprite = roofIcon;
                blockUI.image.sprite = testhouse2Roof;
                break;
            case BlockType.testHouse2FloorSmall:
                blockUI.border.sprite = floorBorder;
                blockUI.levelIcon.sprite = floorIcon;
                blockUI.image.sprite = testhouse2FloorSmall;
                break;

            case BlockType.testhouse3Foundation:
                blockUI.border.sprite = foundationBorder;
                blockUI.levelIcon.sprite = foundationIcon;
                blockUI.image.sprite = testhouse3Foundation;
                break;
            case BlockType.testhouse3Floor:
                blockUI.border.sprite = floorBorder;
                blockUI.levelIcon.sprite = floorIcon;
                blockUI.image.sprite = testhouse3Floor;
                break;
            case BlockType.testHouse3Roof:
                blockUI.border.sprite = roofBorder;
                blockUI.levelIcon.sprite = roofIcon;
                blockUI.image.sprite = testhouse3Roof;
                break;
            case BlockType.testHouse3FloorSmall:
                blockUI.border.sprite = floorBorder;
                blockUI.levelIcon.sprite = floorIcon;
                blockUI.image.sprite = testhouse3FloorSmall;
                break;


            case BlockType.testHouseFenceSmall:
                blockUI.border.sprite = foundationBorder;
                blockUI.levelIcon.sprite = foundationIcon;
                blockUI.image.sprite = testhouseFenceSmall;
                break;
            case BlockType.testHouseFenceLarge:
                blockUI.border.sprite = foundationBorder;
                blockUI.levelIcon.sprite = foundationIcon;
                blockUI.image.sprite = testhouseFenceLarge;
                break;

            case BlockType.greekFloorBig:
                blockUI.border.sprite = floorBorder;
                blockUI.levelIcon.sprite = floorIcon;
                blockUI.image.sprite = greekFloorBig;
                break;
            case BlockType.greekFloorBigAndWide:
                blockUI.border.sprite = floorBorder;
                blockUI.levelIcon.sprite = floorIcon;
                blockUI.image.sprite = greekFloorBigAndWide;
                break;
            case BlockType.greekFloorPillars:
                blockUI.border.sprite = floorBorder;
                blockUI.levelIcon.sprite = floorIcon;
                blockUI.image.sprite = greekFloorPillars;
                break;
            case BlockType.greekFoundation:
                blockUI.border.sprite = foundationBorder;
                blockUI.levelIcon.sprite = foundationIcon;
                blockUI.image.sprite = greekFoundation;
                break;
            case BlockType.greekRoof:
                blockUI.border.sprite = roofBorder;
                blockUI.levelIcon.sprite = roofIcon;
                blockUI.image.sprite = greekRoof;
                break;
            case BlockType.greekRoofTiny:
                blockUI.border.sprite = roofBorder;
                blockUI.levelIcon.sprite = roofIcon;
                blockUI.image.sprite = greekRoofTiny;
                break;
            case BlockType.mountainFloorLarge:
                blockUI.border.sprite = floorBorder;
                blockUI.levelIcon.sprite = floorIcon;
                blockUI.image.sprite = mountainFloorLarge;
                break;
            case BlockType.mountainFloorSmall:
                blockUI.border.sprite = floorBorder;
                blockUI.levelIcon.sprite = floorIcon;
                blockUI.image.sprite = mountainFloorSmall;
                break;
            case BlockType.mountainFoundationLarge:
                blockUI.border.sprite = foundationBorder;
                blockUI.levelIcon.sprite = foundationIcon;
                blockUI.image.sprite = mountainFoundationLarge;
                break;
            case BlockType.mountainFoundationSmall:
                blockUI.border.sprite = foundationBorder;
                blockUI.levelIcon.sprite = foundationIcon;
                blockUI.image.sprite = mountainFoundationSmall;
                break;
            case BlockType.mountainRoofLarge:
                blockUI.border.sprite = floorBorder;
                blockUI.levelIcon.sprite = floorIcon;
                blockUI.image.sprite = mountainRoofLarge;
                break;
            case BlockType.mountainRoofSmall:
                blockUI.border.sprite = floorBorder;
                blockUI.levelIcon.sprite = floorIcon;
                blockUI.image.sprite = mountainRoofSmall;
                break;
        }
    }

    public void UpdateBlocksLeftText(int blocksLeft)
    {
        blocksLeftText.text = blocksLeftString + blocksLeft;
    }
}
