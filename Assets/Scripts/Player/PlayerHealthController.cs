using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerHealthController : MonoBehaviour
{
	public static PlayerHealthController instance;

	public int currentHealth;
	public int maxHealth;

	private void Awake()
	{
		instance = this;
	}

	private void Start()
	{
		currentHealth = maxHealth;

		UIController.instance.healthSlider.maxValue = maxHealth;
		UIController.instance.healthSlider.value = currentHealth;
		UIController.instance.healthText.text = currentHealth.ToString();
	}

	public void DamagePlayer()
	{
		currentHealth--;

		if(currentHealth <= 0)
		{
			PlayerController.instance.gameObject.SetActive(false);
		}

		UIController.instance.healthSlider.value = currentHealth;
		UIController.instance.healthText.text = currentHealth.ToString();
	}
}
