using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TipBlur : MonoBehaviour
{
	public void DisableObject()
	{
		gameObject.SetActive(false);
	}

	public void OpenSound()
	{
		AudioManager.instance.PlaySFX(6);
	}

	public void CloseSound()
	{
		AudioManager.instance.PlaySFX(1);
	}
}
