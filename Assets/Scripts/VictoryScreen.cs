using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class VictoryScreen : MonoBehaviour
{
	public float waitForAnyKey = 3f;

	public GameObject anyKeyText;

	public string mainMenuScene;

	private void Update()
	{
		if(waitForAnyKey > 0)
		{
			waitForAnyKey -= Time.deltaTime;
			if(waitForAnyKey <= 0)
			{
				anyKeyText.SetActive(true);
			}
		}
	}
}
