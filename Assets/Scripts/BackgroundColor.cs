using System.Collections;
using System.Collections.Generic;
using System.Security.Cryptography;
using UnityEngine;

public class BackgroundColor : MonoBehaviour
{
    Color color;
    [SerializeField] SpriteRenderer tiles1;
    [SerializeField] SpriteRenderer tiles2;

    public Color[] colorArray;

	private void Start()
	{
		colorArray = new Color[10];

		colorArray[0] = new Color32(126, 218, 229, 255); //default blue
		colorArray[1] = new Color32(255, 157, 46, 255); //orange strength
		colorArray[2] = new Color32(149, 255, 137, 255); //green health
		colorArray[3] = new Color32(57, 157, 46, 255); //blue stamina
		colorArray[4] = new Color32(255, 103, 190, 255); //pink friendship

		color = colorArray[0];
	}

	void Update()
    {
        tiles1.color = Color.Lerp(tiles1.color, color, Time.deltaTime);
        tiles2.color = Color.Lerp(tiles2.color, color, Time.deltaTime);
    }

    public void OnColorChange(int colorNum)
    {
        color = colorArray[colorNum];
    }
}
