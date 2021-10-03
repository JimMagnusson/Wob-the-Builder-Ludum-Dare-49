using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class LevelCompletionTracker : MonoBehaviour
{
    // Assumes level 1 has buildIndex 1 , etc.
    public void SaveCurrentLevelAsCompleted()
    {
        int currentLevel = SceneManager.GetActiveScene().buildIndex;
        PlayerPrefs.SetInt("Level" + currentLevel, 1);
    }

    public bool IsLevelCompleted(int level)
    {
        int completed = PlayerPrefs.GetInt("Level" + level, 0);
        return completed == 1;
    }
}
