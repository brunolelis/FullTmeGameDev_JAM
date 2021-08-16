using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemySpawner : MonoBehaviour
{
	[SerializeField] private float spawnRadius = 7, time = 1.5f, lowerTimer = 0.005f;

	public GameObject[] enemies;

	private void Start()
	{
		StartCoroutine(SpawnEnemy());
	}

	IEnumerator SpawnEnemy()
	{
		Vector2 spawnPos = PlayerController.instance.transform.position;
		spawnPos += Random.insideUnitCircle.normalized * spawnRadius;

		Instantiate(enemies[Random.Range(0, enemies.Length)], spawnPos, Quaternion.identity);

		if(time > 0.3f)
			time -= lowerTimer;

		yield return new WaitForSeconds(time);

		StartCoroutine(SpawnEnemy());
	}
}
