using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerBullet : MonoBehaviour
{
	[SerializeField] private float speed = 7.5f;
	private Rigidbody2D theRB;

	public GameObject impactEffect;

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
	}

	private void OnBecameInvisible()
	{
		Destroy(gameObject);
	}
}
