using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Quest_2 : MonoBehaviour
{
	public static Quest_2 instance;

	public int questValue;
	public int currentQuest;

	public GameObject blur;
	public GameObject activeTip;

	private Button thisButton;

	private void Awake()
	{
		currentQuest += 0;
		currentQuest = PlayerPrefs.GetInt("Quest_2");

		instance = this;
	}

	private void Start()
	{
		currentQuest = PlayerPrefs.GetInt("Quest_2");
		thisButton = GetComponent<Button>();
	}

	private void Update()
	{
		if (currentQuest > 0)
		{
			blur.SetActive(false);
		}
		else
		{
			if (Quest_1.instance.currentQuest == 0)
				thisButton.interactable = false;
			blur.SetActive(true);
		}

		if(Quest_1.instance.currentQuest > 0)
		{
			thisButton.interactable = true;
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
			Menu.instance.GetCoins(500);
			activeTip.SetActive(true);

			currentQuest++;
			PlayerPrefs.SetInt("Quest_2", currentQuest);
		}
	}
}
