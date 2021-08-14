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

	private void Awake()
	{
		instance = this;
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

	private void Start()
	{
		currentHealth = maxHealth;

		UIController.instance.healthSlider.maxValue = maxHealth;
		UIController.instance.healthSlider.value = currentHealth;
		UIController.instance.healthText.text = currentHealth.ToString();
	}

	public void DamagePlayer()
	{
		if(invincCount <= 0)
		{
			currentHealth--;

			invincCount = damageInvincLenght;

			PlayerController.instance.bodySR.color = new Color(PlayerController.instance.bodySR.color.r, PlayerController.instance.bodySR.color.g, PlayerController.instance.bodySR.color.b, 0.5f);

			if (currentHealth <= 0)
			{
				PlayerController.instance.gameObject.SetActive(false);

				UIController.instance.deathScreen.SetActive(true);
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
}
