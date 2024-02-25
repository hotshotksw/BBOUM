using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class WinScreens : MonoBehaviour
{
	[SerializeField] private Image image;
	[SerializeField] private Image background;

	[SerializeField] private bool useBaseWinScreen;

	[Serializable]
	struct layouts
	{
		public GameObject buttonsandtext;
		public Color backgroundColor;
		public Sprite image;
	}

	[SerializeField] private layouts[] layout;
	[SerializeField] private List<layouts> availableLayouts;
	[SerializeField] private int selected;
	[SerializeField] private GameObject layoutSwitchers;

	[SerializeField] private FloatVariable strength;
	[SerializeField] private FloatVariable stamina;
	[SerializeField] private FloatVariable health;
	[SerializeField] private FloatVariable friendship;

	private void OnEnable()
	{
		availableLayouts = new List<layouts>();
		useBaseWinScreen = true;

		if (strength.value >= 50)
		{
			availableLayouts.Add(layout[0]);
			useBaseWinScreen = false;
		}
		if (stamina.value >= 50)
		{
			availableLayouts.Add(layout[1]);
			useBaseWinScreen = false;
		}
		if (health.value >= 50)
		{
			availableLayouts.Add(layout[2]);
			useBaseWinScreen = false;
		}
		if (friendship.value >= 50)
		{
			availableLayouts.Add(layout[3]);
			useBaseWinScreen = false;
		}

		if (useBaseWinScreen)
		{
			availableLayouts.Add(layout[4]);
		}

		layoutSwitchers.SetActive(availableLayouts.Count > 1);

		SetUpLayout();
	}

	public void NextLayout()
	{
		availableLayouts[selected].buttonsandtext.SetActive(false);
		selected++;
		if (selected >= availableLayouts.Count)
		{
			selected = 0;
		}
		SetUpLayout();
	}

	public void PrevLayout()
	{
		availableLayouts[selected].buttonsandtext.SetActive(false);
		selected--;
		if (selected < 0)
		{
			selected = availableLayouts.Count - 1;
		}
		SetUpLayout();
	}

	public void SetUpLayout()
	{
		if (availableLayouts[selected].image)
		{
			image.sprite = availableLayouts[selected].image;
			image.color = Color.white;
		} else
		{
			image.color = availableLayouts[selected].backgroundColor;
		}
		background.color = availableLayouts[selected].backgroundColor;
		availableLayouts[selected].buttonsandtext.SetActive(true);
	}
}
