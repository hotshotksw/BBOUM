using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CharacterAnimator : MonoBehaviour
{
	[SerializeField] public Animator animator;

	public void ActivateAnimation(string anim)
	{
		animator.ResetTrigger(anim);
		animator.SetTrigger(anim);
	}
}
