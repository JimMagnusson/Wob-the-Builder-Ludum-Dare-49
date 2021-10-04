using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MusicPlayer : MonoBehaviour
{
	public static MusicPlayer Instance = null;

	private AudioSource audioSource;
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

	public void MuteToggle()
    {
		if(!toggled)
        {
			toggled = true;
			audioSource.mute = true;
		}
		else
        {
			toggled = false;
			audioSource.mute = false;
		}
	}
}
