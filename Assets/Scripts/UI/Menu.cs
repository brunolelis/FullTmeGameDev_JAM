using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using TMPro;

public class Menu : MonoBehaviour
{
	public static Menu instance;

	public string levelToLoad;

	public TextMeshProUGUI coinDisplay;
	public int currentCoins;

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
}
