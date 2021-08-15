using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Audio;

public class SetVolume : MonoBehaviour
{
	public AudioMixer music;
	public AudioMixer sfx;

	public void SetMusicLevel(float sliderValue)
	{
		music.SetFloat("MusicVol", Mathf.Log10(sliderValue) * 20);
	}

	public void SetSFXLevel(float sliderValue)
	{
		sfx.SetFloat("SFXVol", Mathf.Log10(sliderValue) * 20);
	}
}
