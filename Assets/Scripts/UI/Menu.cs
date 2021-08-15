using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Menu : MonoBehaviour
{
	public string levelToLoad;

	public void StartGame()
	{
		SceneManager.LoadScene(levelToLoad);
	}

	public void ExitGame()
	{
		Application.Quit();
	}
}
