using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManager : MonoBehaviour
{
    public static GameManager Instance = null;

    [SerializeField] bool gameMuted;

    public bool IsGameMuted()
    {
        return gameMuted;
    }

    private void Awake()
    {
        if (Instance == null)
        {
            Instance = this;
        }
        else if (Instance != this)
        {
            Destroy(gameObject);
        }
        DontDestroyOnLoad(gameObject);
    }
    void Start()
    {
        Application.targetFrameRate = 60; // My GPU makes a grinding noise otherwise
    }

    public void MuteGame(bool mute)
    {
        gameMuted = mute;
    }

    public void TogglePause(bool pause)
    {
        if(pause)
        {
            Time.timeScale = 0;
        }
        else
        {
            Time.timeScale = 1;
        }
    }
}
