using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyController : MonoBehaviour
{
	private Rigidbody2D theRB;
	private Animator anim;

	public GameObject hitEffect;
	public GameObject deathEffect;

	[SerializeField] private float moveSpeed = 3f;
	private Vector2 moveDirection;

	public int health = 150;

	[SerializeField] private bool shouldShoot;

	[SerializeField] private GameObject bullet;
	[SerializeField] private Transform firePoint;
	[SerializeField] private float fireRate = 0.2f;
	private float fireCounter;

	private void Awake()
	{
		theRB = GetComponent<Rigidbody2D>();
		anim = GetComponentInChildren<Animator>();
	}

	private void Update()
	{
		moveDirection = PlayerController.instance.transform.position - transform.position;
		moveDirection.Normalize();

		theRB.velocity = moveDirection * moveSpeed;

		RotateTowards(PlayerController.instance.transform.position);

		if (shouldShoot)
		{
			fireCounter -= Time.deltaTime;

			if (fireCounter <= 0)
			{
				fireCounter = fireRate;
				Instantiate(bullet, transform.position, transform.rotation);
			}
		}
	}

	public void DamageEnemy(int damage)
	{
		health -= damage;
		Instantiate(hitEffect, transform.position, transform.rotation);

		if (health <= 0)
		{
			Instantiate(deathEffect, transform.position, transform.rotation);
			Destroy(gameObject);
		}
	}

	private void RotateTowards(Vector2 target)
	{
		var offset = 90f;
		Vector2 direction = target - (Vector2)transform.position;
		direction.Normalize();
		float angle = Mathf.Atan2(direction.y, direction.x) * Mathf.Rad2Deg;
		transform.rotation = Quaternion.Euler(Vector3.forward * (angle + offset));
	}
}
