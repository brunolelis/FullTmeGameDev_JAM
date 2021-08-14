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
	}

	public void DamagePlayer()
	{
		currentHealth--;

		if(currentHealth <= 0)
		{
			PlayerController.instance.gameObject.SetActive(false);
		}
	}
}
