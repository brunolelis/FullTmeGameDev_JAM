using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AudioManager : MonoBehaviour
{
	public static AudioManager instance;

	public AudioSource levelMusic, gameOverMusic, winMusic;

	public AudioSource[] sfx;

	private void Awake()
	{
		instance = this;
	}

	public void PlayGameOver()
	{
		levelMusic.Stop();

		gameOverMusic.Play();
	}

	public void PlayLevelWin()
	{
		levelMusic.Stop();

		winMusic.Play();
	}

	public void PlaySFX(int sfxToPlay)
	{
		sfx[sfxToPlay].Stop();
		sfx[sfxToPlay].Play();
	}

	public void LowerLevelMusic()
	{
		levelMusic.volume = 0.2f;
	}

	public void NormalLevelMusic()
	{
		levelMusic.volume = 0.5f;
	}
}
