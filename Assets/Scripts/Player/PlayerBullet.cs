using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerBullet : MonoBehaviour
{
	[SerializeField] private float speed = 7.5f;
	[SerializeField] private int damageToGive = 30;
	private Rigidbody2D theRB;

	public GameObject impactEffect;

	public enum BulletColor { Yellow, Red, Green}
	public BulletColor type;

	private void Awake()
	{
		theRB = GetComponent<Rigidbody2D>();
	}

	private void Update()
	{
		theRB.velocity = transform.right * speed;
	}

	private void OnTriggerEnter2D(Collider2D collision)
	{
		Instantiate(impactEffect, transform.position, transform.rotation);
		Destroy(gameObject);

		AudioManager.instance.PlaySFX(4);

		if (type == BulletColor.Red && collision.tag == "RedEnemy")
		{
			collision.GetComponent<EnemyController>().DamageEnemy(damageToGive);
		}
		else if (type == BulletColor.Green && collision.tag == "GreenEnemy")
		{
			collision.GetComponent<EnemyController>().DamageEnemy(damageToGive);
		}
		else if (type == BulletColor.Yellow && collision.tag == "YellowEnemy")
		{
			collision.GetComponent<EnemyController>().DamageEnemy(damageToGive);
		}
	}

	private void OnBecameInvisible()
	{
		Destroy(gameObject);
	}
}
