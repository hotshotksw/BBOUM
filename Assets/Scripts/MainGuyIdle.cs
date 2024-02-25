using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MainGuyIdle : MonoBehaviour
{
    [SerializeField] private Animator animator;
	[SerializeField] private SpriteRenderer spriteRenderer;
    [SerializeField] float walkArea = 5;
	float desiredPos = 0;
	float startPos;

	private void Start()
	{
		startPos = animator.transform.position.x;
	}

	private void Update()
	{
		if (animator.GetBool("Moving"))
		{
			animator.transform.position = new Vector3(Mathf.Lerp(animator.transform.position.x, desiredPos, Time.deltaTime), 0, 0);
		}
	}

	IEnumerator Wander()
	{
        while (true)
        {
			animator.SetBool("Moving", false);
			yield return new WaitForSeconds(Random.Range(1, 5));
			desiredPos = startPos + Random.Range(-walkArea, walkArea);
			if (desiredPos < animator.transform.position.x)
			{
				spriteRenderer.flipX = false;
			} else
			{
				spriteRenderer.flipX = true;
			}
			animator.SetBool("Moving", true);
			yield return new WaitUntil(() => Mathf.Abs(animator.transform.position.x - desiredPos) < 0.1f);
		}
	}

	private void OnEnable()
	{
		StartCoroutine(Wander());
	}

	public void OnDisable()
	{
		StopAllCoroutines();
	}
}
