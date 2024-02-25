using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class WinScreens : MonoBehaviour
{
	[SerializeField] private Image image;

	[SerializeField] private bool useBaseWinScreen;
	[SerializeField] private VoidEvent strengthColorEvent;
	[SerializeField] private VoidEvent staminaColorEvent;
	[SerializeField] private VoidEvent healthColorEvent;
	[SerializeField] private VoidEvent friendshipColorEvent;
	[SerializeField] private VoidEvent baseColorEvent;

	[Serializable]
	struct layouts
	{
		public GameObject buttonsandtext;
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
	[SerializeField] private AudioSource winSound;

	private void OnEnable()
	{
		winSound.Play();
		foreach (layouts layout in availableLayouts)
		{
			layout.buttonsandtext.SetActive(false);
		}
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

		strength.value = 0;
		stamina.value = 0;
		health.value = 0;
		friendship.value = 0;

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
		image.sprite = availableLayouts[selected].image;
		switch (selected) {
			case 0:
				strengthColorEvent.RaiseEvent();
				break;
			case 1:
				staminaColorEvent.RaiseEvent();
				break;
			case 2:
				healthColorEvent.RaiseEvent();
				break;
			case 3:
				friendshipColorEvent.RaiseEvent();
				break;
			case 4:
				baseColorEvent.RaiseEvent();
				break;
		}
		availableLayouts[selected].buttonsandtext.SetActive(true);
	}
}
