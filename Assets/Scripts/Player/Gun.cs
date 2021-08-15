using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Gun : MonoBehaviour
{
	[Space]
	[Header("Shoot:")]
	[SerializeField] private GameObject bulletToFire;
	private Transform firePoint;
	[SerializeField] private float timeBetweenShots = 0.2f;
	private float shotCounter;

	private void Awake()
	{
		firePoint = transform.Find("PistolPoint");
	}

	private void Update()
	{
		if (!UIController.instance.isPaused)
		{
			Shoot();
		}
	}

	void Shoot()
	{
		if(shotCounter > 0)
		{
			shotCounter -= Time.deltaTime;
		}
		else
		{
			if (Input.GetMouseButtonDown(0) || Input.GetMouseButton(0))
			{
				Instantiate(bulletToFire, firePoint.position, firePoint.rotation);
				shotCounter = timeBetweenShots;
				AudioManager.instance.PlaySFX(14);
			}
		}
	}

}
