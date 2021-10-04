using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MusicPlayer : MonoBehaviour
{
	public static MusicPlayer Instance = null;

	private AudioSource audioSource;
	private GameManager gameManager;
	private bool toggled = false;

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

		audioSource = GetComponent<AudioSource>();
	}

    private void Start()
    {
		gameManager = FindObjectOfType<GameManager>();

	}

    public void MuteToggle()
    {
		if(!toggled)
        {
			toggled = true;
			audioSource.mute = true;
			gameManager.MuteGame(true);
		}
		else
        {
			toggled = false;
			audioSource.mute = false;
			gameManager.MuteGame(false);
		}
	}
}
