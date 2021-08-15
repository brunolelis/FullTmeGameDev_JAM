using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Quest_2 : MonoBehaviour
{
	public int questValue;
	public int currentQuest;

	public GameObject blur;
	public GameObject activeTip;

	private void Awake()
	{
		currentQuest += 0;
		currentQuest = PlayerPrefs.GetInt("Quest_2");
	}

	private void Start()
	{
		currentQuest = PlayerPrefs.GetInt("Quest_2");
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
		PlayerPrefs.SetInt("Quest_2", currentQuest);
	}

	public void ConfirmQuest2()
	{
		if (currentQuest == 1)
		{
			Menu.instance.GetCoins(350);
			activeTip.SetActive(true);

			currentQuest++;
			PlayerPrefs.SetInt("Quest_2", currentQuest);
		}
	}
}
