using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;
using UnityEngine.SceneManagement;

public class UIController : MonoBehaviour
{
	public static UIController instance;

	public Slider healthSlider;
	public TextMeshProUGUI healthText;

	public Image fadeScreen;
	public float fadeSpeed;
	private bool fadeToBlack, fadeOutBlack;

	public GameObject deathScreen;
	public GameObject pauseMenu;
	[HideInInspector] public bool isPaused;

	public string newGameScene, mainMenuScene;

	public TextMeshProUGUI coinDisplay;

	public Image currentGun;
	public Image gunColorLayout;

	private void Awake()
	{
		instance = this;
	}

	private void Start()
	{
		Time.timeScale = 1f;

		fadeOutBlack = true;
		fadeToBlack = false;

		fadeScreen.color = new Color(fadeScreen.color.r, fadeScreen.color.g, fadeScreen.color.b, 1f);
	}

	private void Update()
	{
		if (Input.GetKeyDown(KeyCode.Escape))
		{
			PauseUnpause();
		}

		if (fadeOutBlack)
		{
			fadeScreen.color = new Color(fadeScreen.color.r, fadeScreen.color.g, fadeScreen.color.b, Mathf.MoveTowards(fadeScreen.color.a, 0f, fadeSpeed * Time.deltaTime));
			if (fadeScreen.color.a == 0f)
			{
				fadeOutBlack = false;
			}
		}

		if (fadeToBlack)
		{
			fadeScreen.color = new Color(fadeScreen.color.r, fadeScreen.color.g, fadeScreen.color.b, Mathf.MoveTowards(fadeScreen.color.a, 1f, fadeSpeed * Time.deltaTime));
			if (fadeScreen.color.a == 1f)
			{
				fadeToBlack = false;
			}
		}
	}

	public void StartFadeToBlack()
	{
		fadeToBlack = true;
		fadeOutBlack = false;
	}

	public void PauseUnpause()
	{
		if (!isPaused)
		{
			AudioManager.instance.PlaySFX(21);
			AudioManager.instance.LowerLevelMusic();

			pauseMenu.SetActive(true);

			isPaused = true;

			Time.timeScale = 0f;
		}
		else
		{
			AudioManager.instance.PlaySFX(22);
			AudioManager.instance.NormalLevelMusic();

			pauseMenu.SetActive(false);

			isPaused = false;

			Time.timeScale = 1f;
		}
	}

	public void NewGame()
	{
		StartFadeToBlack();
		Time.timeScale = 1f;
		SceneManager.LoadScene(newGameScene);
	}

	public void ReturnToMenu()
	{
		StartFadeToBlack();
		Time.timeScale = 1f;
		SceneManager.LoadScene(mainMenuScene);
	}
}
