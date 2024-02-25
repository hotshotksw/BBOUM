using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpamClickNow : MonoBehaviour
{
	int clicks = 100;

	private void OnEnable()
	{
		clicks = 100;
	}

	private void Update()
	{
		if (Input.GetKeyDown(KeyCode.Space) || Input.GetMouseButtonDown(0))
		{
			clicks--;
			if (clicks <= 0)
			{
				gameObject.SetActive(false);
			}
		}
	}
}
