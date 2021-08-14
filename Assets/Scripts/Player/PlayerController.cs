using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
	public static PlayerController instance;

	[Space]
	[Header("Character attributes:")]
	[SerializeField] private float MOVEMENT_BASE_SPEED = 1.0f;
	[SerializeField] private float GUN_BODY_DISTANCE = 0.2f;

	[Space]
	[Header("Character statistics:")]
	[SerializeField] private float movementSpeed;
	[SerializeField] private float range = 3f;
	[HideInInspector] public Vector2 movementDirection;
	private Vector2 moveInput;
	[SerializeField] private float turnSpeed = 3f;
	[SerializeField] private float AimturnSpeed = 5f;
	[HideInInspector] public bool endOfAiming, isAiming;
	[HideInInspector] public bool addEnemy = true;
	[SerializeField]
	private float dashSpeed = 5f, dashLenght = 0.5f, dashCooldown = 1f, dashinvincibility = 0.5f;
	[HideInInspector] public float dashCoolCounter;
	[HideInInspector] public float dashCounter;
	private float movement_base_speed_start;
	[HideInInspector] public bool reloadTrigger = false;

	[Space]
	[Header("References:")]
	private Rigidbody2D rb;
	private Animator animator;
	private Transform gunArm;
	private Camera theCam;
	[HideInInspector] public Transform target;
	[HideInInspector] public SpriteRenderer bodySR;
	[HideInInspector] public bool canMove = true;
	private readonly string enemyTag = "Enemy";

	[Space]
	[Header("Shoot:")]
	[SerializeField] private GameObject bulletToFire;
	private Transform firePoint;
	[SerializeField] private float timeBetweenShots = 0.2f;
	private float shotCounter;

	#region Awake & Start
	private void Awake()
	{
		rb = GetComponent<Rigidbody2D>();
		animator = GetComponentInChildren<Animator>();
		gunArm = transform.Find("Gun Hand");
		bodySR = GetComponentInChildren<SpriteRenderer>();
		firePoint = transform.Find("Gun Hand").Find("PistolPoint");

		instance = this;
	}

	private void Start()
	{
		theCam = Camera.main;

		movement_base_speed_start = MOVEMENT_BASE_SPEED;
	}
	#endregion

	#region Updates
	private void Update()
	{
		Move();
		Dash();
		Animate();
		Aim();
		Shoot();
	}
	#endregion

	#region Animation
	void Animate()
	{
		if (movementDirection != Vector2.zero)
		{
			animator.SetFloat("Horizontal", movementDirection.x);
			animator.SetFloat("Vertical", movementDirection.y);
		}
		animator.SetFloat("Speed", movementSpeed);
	}
	#endregion

	#region Movement
	void Move()
	{
		rb.velocity = moveInput * movementSpeed * MOVEMENT_BASE_SPEED;

		moveInput = new Vector2(Input.GetAxisRaw("Horizontal"), Input.GetAxisRaw("Vertical"));
		movementSpeed = Mathf.Clamp(moveInput.magnitude, 0.0f, 1.0f);
		moveInput.Normalize();
	}
	#endregion

	#region Dash
	private void Dash()
	{
		if (dashCounter > 0)
		{
			dashCounter -= Time.deltaTime;

			if (dashCounter <= 0)
			{
				MOVEMENT_BASE_SPEED = movement_base_speed_start;
				dashCoolCounter = dashCooldown;
			}
		}

		if (dashCoolCounter > 0)
		{
			dashCoolCounter -= Time.deltaTime;
		}
	}

	public void PressDash()
	{
		if (dashCoolCounter <= 0 && dashCounter <= 0)
		{
			MOVEMENT_BASE_SPEED = dashSpeed;
			dashCounter = dashLenght;

			animator.SetTrigger("DashTrigger");

			//PlayerHealthController.instance.MakeInvincible(dashinvincibility);
		}
	}
	#endregion

	#region Aim
	void Aim()
	{
		gunArm.transform.localPosition = movementDirection * GUN_BODY_DISTANCE;

		Vector2 mouseMovement = Input.mousePosition;
		Vector2 screenPoint = theCam.WorldToScreenPoint(transform.localPosition);

		//rotate the gun
		Vector2 offset = new Vector2(mouseMovement.x - screenPoint.x, mouseMovement.y - screenPoint.y);
		float angle = Mathf.Atan2(offset.y, offset.x) * Mathf.Rad2Deg;
		gunArm.rotation = Quaternion.Slerp(gunArm.rotation, Quaternion.Euler(0, 0, angle), Time.deltaTime * turnSpeed);

		movementDirection += offset;
		movementDirection.Normalize();

		if (mouseMovement.x > movementDirection.x)
		{
			gunArm.localScale = new Vector3(1f, -1f, 1f);
		}
		else
		{
			gunArm.localScale = Vector3.one;
		}
	}
	#endregion

	#region Shoot
	void Shoot()
	{
		if (Input.GetMouseButtonDown(0))
		{
			Instantiate(bulletToFire, firePoint.position, firePoint.rotation);
			shotCounter = timeBetweenShots;
		}

		if (Input.GetMouseButton(0))
		{
			shotCounter -= Time.deltaTime;

			if(shotCounter <= 0)
			{
				Instantiate(bulletToFire, firePoint.position, firePoint.rotation);

				shotCounter = timeBetweenShots;
			}
		}
	}
	#endregion
}
