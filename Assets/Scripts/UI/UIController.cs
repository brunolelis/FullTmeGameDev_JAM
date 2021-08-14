using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class UIController : MonoBehaviour
{
	public static UIController instance;

	public Slider healthSlider;
	public TextMeshProUGUI healthText;

	public GameObject deathScreen;

	private void Awake()
	{
		instance = this;
	}
}
