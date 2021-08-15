using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Quest_3 : MonoBehaviour
{
	public int questValue;
	public int currentQuest;

	public GameObject blur;

	private void Awake()
	{
		currentQuest += 0;
		currentQuest = PlayerPrefs.GetInt("Quest_3");
	}

	private void Start()
	{
		currentQuest = PlayerPrefs.GetInt("Quest_3");
	}

	private void Update()
	{
		if (currentQuest > 0)
		{
			blur.SetActive(false);
		}
		else
		{
			blur.SetActive(true);
		}
	}

	public void BuyQuest()
	{
		if (questValue > Menu.instance.currentCoins || currentQuest > 0)
			return;

		Menu.instance.SpendCoins(questValue);
		currentQuest++;
		PlayerPrefs.SetInt("Quest_3", currentQuest);
	}

	public void ConfirmQuest3()
	{
		if (currentQuest == 1)
		{
			SceneManager.LoadScene(2);
		}
	}
}
