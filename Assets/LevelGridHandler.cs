using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LevelGridHandler : MonoBehaviour
{
    [SerializeField] private LevelIcon[] levelIcons = null;
    private void Awake()
    {
        int levelNumber = 1;
        foreach(LevelIcon levelIcon in levelIcons)
        {
            levelIcon.LevelNumber = levelNumber;
            levelNumber++;
        }
    }

    public void ToggleActive()
    {
        if(gameObject.activeSelf)
        {
            gameObject.SetActive(false);
        }
        else
        {
            gameObject.SetActive(true);
        }
    }
}
