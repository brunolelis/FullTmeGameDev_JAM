using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyBullet : MonoBehaviour
{
	[SerializeField] private float speed;
	private Vector3 direction;

	public GameObject impactEffect;

	private void Start()
	{
		direction = PlayerController.instance.transform.position - transform.position;
		direction.Normalize();
	}

	private void Update()
	{
		transform.position += direction * speed * Time.deltaTime;
	}

	private void OnTriggerEnter2D(Collider2D collision)
	{
		if(collision.tag == "Player")
		{
			PlayerHealthController.instance.DamagePlayer();
			Instantiate(impactEffect, transform.position, transform.rotation);
		}

		Destroy(gameObject);
		AudioManager.instance.PlaySFX(4);
	}

	private void OnBecameInvisible()
	{
		Destroy(gameObject);
	}
}
