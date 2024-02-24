using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class BeatOnTheBar : MonoBehaviour
{
	[SerializeField] Vector3 start;
	[SerializeField] Vector3 end;

	[SerializeField] private float speed = 1;
	float beatprogress = 0;

	public void SetupBeat(Vector3 start, Vector3 end, float speed)
	{
		this.start = start;
		this.end = end;
		this.speed = speed;
	}

	private void Update()
	{
		transform.position = Vector3.Lerp(start, end, beatprogress);
		beatprogress += ((speed / Vector2.Distance(start, end)) * Time.deltaTime);
		if (Vector3.Distance(transform.position, end) < 0.01f)
		{
			Destroy(gameObject);
		}
	}
}
