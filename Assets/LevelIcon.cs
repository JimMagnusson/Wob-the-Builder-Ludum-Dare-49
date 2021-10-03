using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class LevelIcon : MonoBehaviour
{
    [SerializeField] private Image completed = null;
    [SerializeField] private TextMeshProUGUI levelNumberText = null;
    [SerializeField] private LevelCompletionTracker levelCompletionTracker = null;
    [SerializeField] private LevelLoader levelLoader  = null;
    public int LevelNumber { get; set; }

    private void Start()
    {
        if(levelNumberText == null) { Debug.Log("Check levelNumberText reference.");  }
        if (levelCompletionTracker == null) { Debug.Log("Check levelCompletionTracker reference."); }
        if (completed == null) { Debug.Log("Check completed reference."); }
        if (levelLoader == null) { Debug.Log("Check levelLoader reference."); }

        levelNumberText.text = LevelNumber.ToString();

        if(levelCompletionTracker.IsLevelCompleted(LevelNumber))
        {
            completed.gameObject.SetActive(true);
        }
    }

    public void LoadIconLevel()
    {
        levelLoader.LoadSceneWithBuildIndex(LevelNumber);
    }
}
