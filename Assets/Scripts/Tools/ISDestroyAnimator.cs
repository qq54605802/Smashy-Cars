using UnityEngine;
using System.Collections;

public class ISDestroyAnimator : StateMachineBehaviour {

	override public void OnStateExit(Animator animator, AnimatorStateInfo animatorStateInfo, int layerIndex){
		ISObjectPoolManager.Unspawn (animator.gameObject);
	}
}
