using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyController : MonoBehaviour
{
	private Rigidbody2D theRB;
	private Animator anim;

	[SerializeField] private float moveSpeed = 3f;
	private Vector2 moveDirection;

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
	}
}
