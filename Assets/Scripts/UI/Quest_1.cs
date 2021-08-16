using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Quest_1 : MonoBehaviour
{
	public static Quest_1 instance;

	public int questValue;
	public int currentQuest;

	public GameObject blur;
	private Button thisButton;

	private void Awake()
	{
		currentQuest += 0;
		currentQuest = PlayerPrefs.GetInt("Quest_1");

		instance = this;
	}

	private void Start()
	{
		currentQuest = PlayerPrefs.GetInt("Quest_1");
		thisButton = GetComponent<Button>();
	}

	private void Update()
	{
		if(currentQuest > 0)
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
		PlayerPrefs.SetInt("Quest_1", currentQuest);
	}
}
