using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpriteSequencer : MonoBehaviour
{
    [SerializeField] private Sprite[] sprites;
    [SerializeField] private SpriteRenderer spriteRenderer;

	int selection;

	private void Start()
	{
		spriteRenderer = GetComponent<SpriteRenderer>();
		spriteRenderer.sprite = sprites[selection];
	}

	public void NextSprite()
	{
		selection++;
		if (selection >= sprites.Length) 
		{
			selection = 0;
		}

		spriteRenderer.sprite = sprites[selection];
	}
}
