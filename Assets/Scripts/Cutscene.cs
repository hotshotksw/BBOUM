using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Cutscene : MonoBehaviour
{
	[SerializeField] Animator animator;
	[SerializeField] private AudioSource music;
	[SerializeField] VoidEvent endCutscene;
	[SerializeField] GameObject beatBar;

	public void StartCutscene()
	{
		beatBar.SetActive(false);
		animator.SetTrigger("Start");
		music.Play();
	}

	public void EndCutscene()
	{
		endCutscene.RaiseEvent();
	}
}
