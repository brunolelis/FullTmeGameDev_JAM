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

		if(type == BulletColor.Red && (collision.tag == "GreenEnemy" || collision.tag == "YellowEnemy"))
		{
			Destroy(gameObject);
		}
		else if (type == BulletColor.Green && (collision.tag == "RedEnemy" || collision.tag == "YellowEnemy"))
		{
			Destroy(gameObject);
		}
		else if (type == BulletColor.Yellow && (collision.tag == "GreenEnemy" || collision.tag == "RedEnemy"))
		{
			Destroy(gameObject);
		}

		if (type == BulletColor.Yellow || type == BulletColor.Green)
		{
			Destroy(gameObject);
		}
	}

	private void OnBecameInvisible()
	{
		Destroy(gameObject);
	}
}
