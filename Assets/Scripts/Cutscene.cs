using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Cutscene : MonoBehaviour
{
	[SerializeField] Animator animator;

	[SerializeField] VoidEvent endCutscene;

	public void StartCutscene()
	{
		animator.SetTrigger("Start");
	}

	public void EndCutscene()
	{
		endCutscene.RaiseEvent();
	}
}
