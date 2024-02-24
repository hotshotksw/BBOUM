using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CharacterAnimator : MonoBehaviour
{
	[SerializeField] public Animator animator;

	private void Start()
	{
		if (!animator)
		{
			animator = GetComponent<Animator>();
		}
	}

	public void ActivateAnimation(string anim)
	{
		animator.ResetTrigger(anim);
		animator.SetTrigger(anim);
	}
}
