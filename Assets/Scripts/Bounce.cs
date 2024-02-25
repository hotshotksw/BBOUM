using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Bounce : MonoBehaviour
{
	[SerializeField] Vector3 baseScale; // base scale of the object

	[SerializeField] bool scaling; // if the object should be bouncing
	[SerializeField, Range(1, Mathf.Infinity)] float bounceSpeed; // how long the bounce should be       how the equation uses it -> (1/bounceSpeed) * bounceTimer
	float a; // a for the equation
	float b; // b for the equation
	float bounceTimer; // time

	private void Start()
	{
		baseScale = transform.localScale;
	}

	private void Update()
	{
		if (scaling)
		{
			float scalar = (-(Mathf.Pow((a * (bounceTimer * bounceSpeed)) - a, 2)) + b);
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

		Debug.Log(scalar);

		scaling = true;
	}
}
