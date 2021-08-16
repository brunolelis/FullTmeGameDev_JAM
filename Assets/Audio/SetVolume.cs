using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.Audio;

public class SetVolume : MonoBehaviour
{
	[SerializeField] private AudioMixer music;
	[SerializeField] private AudioMixer sfx;

	[SerializeField] private Slider musicSlider;
	[SerializeField] private Slider sfxSlider;

	public enum VolumeType { music, sfx }
	public VolumeType type;

	private void Start()
	{
		if (!PlayerPrefs.HasKey("musicVolume") && type == VolumeType.music)
		{
			PlayerPrefs.SetFloat("musicVolume", 1);
			Load();
		}
		else if (!PlayerPrefs.HasKey("sfxVolume") && type == VolumeType.sfx)
		{
			PlayerPrefs.SetFloat("sfxVolume", 1);
			Load();
		}
		else
			Load();
	}

	public void SetMusicLevel(float sliderValue)
	{
		music.SetFloat("MusicVol", Mathf.Log10(sliderValue) * 20);
		Save();
	}

	public void SetSFXLevel(float sliderValue)
	{
		sfx.SetFloat("SFXVol", Mathf.Log10(sliderValue) * 20);
		Save();
	}

	private void Load()
	{
		if(type == VolumeType.music)
			musicSlider.value = PlayerPrefs.GetFloat("musicVolume");
		else
			sfxSlider.value = PlayerPrefs.GetFloat("sfxVolume");
	}

	private void Save()
	{
		if (type == VolumeType.music)
			PlayerPrefs.SetFloat("musicVolume", musicSlider.value);
		else
			PlayerPrefs.SetFloat("sfxVolume", sfxSlider.value);
	}
}
