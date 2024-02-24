using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Bounce : MonoBehaviour
{
	[SerializeField] Vector3 baseScale;

	[SerializeField] bool scaling;

	[SerializeField] float a;
	[SerializeField] float b;
	[SerializeField] float bounceTimer;

	private void Start()
	{
		baseScale = transform.localScale;
	}

	private void Update()
	{
		if (scaling)
		{
			float scalar = (-(Mathf.Pow((a * (bounceTimer * 10f)) - a, 2)) + b);
			transform.localScale = baseScale * (1 + scalar);
			if (transform.localScale.x < baseScale.x)
			{
				scaling = false;
				transform.localScale = baseScale;
			}
			
			bounceTimer += Time.deltaTime;
		}
	}

	public void beatBounce(float scalar)
	{
		a = scalar;
		b = scalar * scalar;
		transform.localScale = baseScale;
		bounceTimer = Time.deltaTime;
		scaling = true;
	}
}
