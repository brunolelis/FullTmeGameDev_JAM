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

	[SerializeField] private bool shouldChasePlayer;
	[SerializeField] private bool shouldShoot;
	[SerializeField] private float runAwayRange;

	[SerializeField] private GameObject bullet;
	[SerializeField] private Transform firePoint;
	[SerializeField] private float fireRate = 0.2f;
	private float fireCounter;

	private SpriteRenderer theBody;

	private int enemyValue;

	private void Awake()
	{
		theRB = GetComponent<Rigidbody2D>();
		anim = GetComponentInChildren<Animator>();
		theBody = GetComponentInChildren<SpriteRenderer>();
	}

	private void Start()
	{
		enemyValue = Random.Range(4, 9);
	}

	private void Update()
	{
		if (theBody.isVisible && PlayerController.instance.gameObject.activeInHierarchy)
		{
			moveDirection = Vector2.zero;

			if (shouldChasePlayer)
			{
				moveDirection = PlayerController.instance.transform.position - transform.position;
			}

			if (shouldShoot)
			{
				fireCounter -= Time.deltaTime;

				if (fireCounter <= 0)
				{
					fireCounter = fireRate;
					Instantiate(bullet, firePoint.position, firePoint.rotation);
					AudioManager.instance.PlaySFX(17);
				}

				if(Vector2.Distance(transform.position, PlayerController.instance.transform.position) > runAwayRange)
				{
					moveDirection = PlayerController.instance.transform.position - transform.position;
				}
				else
				{
					moveDirection = transform.position - PlayerController.instance.transform.position;
				}

			}

			RotateTowards(PlayerController.instance.transform.position);

			moveDirection.Normalize();
			theRB.velocity = moveDirection * moveSpeed;
		}
		else
		{
			theRB.velocity = Vector2.zero;
		}
	}

	public void DamageEnemy(int damage)
	{
		health -= damage;

		AudioManager.instance.PlaySFX(2);

		Instantiate(hitEffect, transform.position, transform.rotation);

		if (health <= 0)
		{
			PlayerHealthController.instance.GetCoins(enemyValue);

			Instantiate(deathEffect, transform.position, transform.rotation);
			ScreenShakeController.instance.StartShake(.05f, .1f);
			Destroy(gameObject);

			AudioManager.instance.PlaySFX(1);
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

	private void OnDrawGizmosSelected()
	{
		if (shouldShoot)
		{
			Gizmos.color = Color.red;
			Gizmos.DrawWireSphere(transform.position, runAwayRange);
		}
	}
}
