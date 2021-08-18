using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;
using TMPro;

public class Menu : MonoBehaviour
{
	public static Menu instance;

	public string levelToLoad;

	public TextMeshProUGUI coinDisplay;
	public int currentCoins;

	public Image fadeScreen;
	public float fadeSpeed;
	private bool fadeToBlack, fadeOutBlack;

	private void Awake()
	{
		instance = this;

		currentCoins += 0;
		currentCoins = PlayerPrefs.GetInt("Coin");
	}

	private void Start()
	{
		currentCoins = PlayerPrefs.GetInt("Coin");
		coinDisplay.text = currentCoins.ToString() + " $";

		fadeOutBlack = true;
		fadeToBlack = false;

		fadeScreen.color = new Color(fadeScreen.color.r, fadeScreen.color.g, fadeScreen.color.b, 1f);
	}

	private void Update()
	{
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


	public void StartGame()
	{
		SceneManager.LoadScene(levelToLoad);
	}

	public void ExitGame()
	{
		Application.Quit();
	}

	public void GetCoins(int amount)
	{
		currentCoins += amount;
		PlayerPrefs.SetInt("Coin", currentCoins);

		coinDisplay.text = currentCoins.ToString() + " $";
	}

	public void SpendCoins(int amount)
	{
		if (amount > currentCoins)
			return;

		currentCoins -= amount;
		PlayerPrefs.SetInt("Coin", currentCoins);

		if (currentCoins < 0)
		{
			currentCoins = 0;
		}

		coinDisplay.text = currentCoins.ToString() + " $";
	}

	public void DeletePlayerPefs()
	{
		PlayerPrefs.DeleteKey("Coin");
		PlayerPrefs.DeleteKey("Quest_1");
		PlayerPrefs.DeleteKey("Quest_2");
		PlayerPrefs.DeleteKey("Quest_3");
		SceneManager.LoadScene(0);
	}
}
