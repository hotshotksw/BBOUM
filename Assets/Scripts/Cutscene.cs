using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Cutscene : MonoBehaviour
{
	[SerializeField] Animator animator;
	[SerializeField] private AudioSource music;
	[SerializeField] VoidEvent endCutscene;

	public void StartCutscene()
	{
		animator.SetTrigger("Start");
		music.Play();
	}

	public void EndCutscene()
	{
		endCutscene.RaiseEvent();
	}
}
