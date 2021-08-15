using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerHealthController : MonoBehaviour
{
	public static PlayerHealthController instance;

	public int currentHealth;
	public int maxHealth;

	public float damageInvincLenght = 1f;
	private float invincCount;

	public int currentCoins;

	private void Awake()
	{
		instance = this;

		currentCoins += 0;
		currentCoins = PlayerPrefs.GetInt("Coin");
	}

	private void Start()
	{
		currentHealth = maxHealth;

		currentCoins = PlayerPrefs.GetInt("Coin");
		UIController.instance.coinDisplay.text = currentCoins.ToString() + " $";

		UIController.instance.healthSlider.maxValue = maxHealth;
		UIController.instance.healthSlider.value = currentHealth;
		UIController.instance.healthText.text = currentHealth.ToString();
	}

	private void Update()
	{
		if (invincCount > 0)
		{
			invincCount -= Time.deltaTime;

			if (invincCount <= 0)
			{
				PlayerController.instance.bodySR.color = new Color(PlayerController.instance.bodySR.color.r, PlayerController.instance.bodySR.color.g, PlayerController.instance.bodySR.color.b, 1f);
			}
		}
	}


	public void DamagePlayer()
	{
		if(invincCount <= 0)
		{
			currentHealth--;

			ScreenShakeController.instance.StartShake(.05f, .1f);

			AudioManager.instance.PlaySFX(11);

			invincCount = damageInvincLenght;

			PlayerController.instance.bodySR.color = new Color(PlayerController.instance.bodySR.color.r, PlayerController.instance.bodySR.color.g, PlayerController.instance.bodySR.color.b, 0.5f);

			if (currentHealth <= 0)
			{
				PlayerController.instance.gameObject.SetActive(false);

				UIController.instance.deathScreen.SetActive(true);

				AudioManager.instance.PlaySFX(10);
				AudioManager.instance.PlayGameOver();
			}

			UIController.instance.healthSlider.value = currentHealth;
			UIController.instance.healthText.text = currentHealth.ToString();
		}
	}

	public void MakeInvincible(float lenght)
	{
		invincCount = lenght;
		PlayerController.instance.bodySR.color = new Color(PlayerController.instance.bodySR.color.r, PlayerController.instance.bodySR.color.g, PlayerController.instance.bodySR.color.b, 0.5f);
	}

	public void GetCoins(int amount)
	{
		currentCoins += amount;
		PlayerPrefs.SetInt("Coin", currentCoins);

		UIController.instance.coinDisplay.text = currentCoins.ToString() + " $";
	}
}
