using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EvaluationScript : MonoBehaviour
{
    [SerializeField] SpriteRenderer spriteRenderer;

    [SerializeField] Sprite ultimate;
    [SerializeField] Sprite niceform;
    [SerializeField] Sprite needswork;
    [SerializeField] Sprite bogus;

    // Start is called before the first frame update
    void Start()
    {
        spriteRenderer = GetComponent<SpriteRenderer>();
    }

    public void Evaluate(float eval)
    {
		spriteRenderer.color = new Color(spriteRenderer.color.r, spriteRenderer.color.g, spriteRenderer.color.b, 1);

		if (eval > 0.9f)
		{
			spriteRenderer.sprite = ultimate;
		}
		else if (eval > 0.5f)
		{
			spriteRenderer.sprite = niceform;
		}
		else if (eval > 0.1f)
		{
			spriteRenderer.sprite = needswork;
		}
		else
		{
			spriteRenderer.sprite = bogus;
		}

		StopAllCoroutines();
		StartCoroutine(FadeAway());
	}

	IEnumerator FadeAway()
	{
		yield return new WaitForSeconds(0.5f);
		spriteRenderer.color = new Color(spriteRenderer.color.r, spriteRenderer.color.g, spriteRenderer.color.b, 0);
	}
}
