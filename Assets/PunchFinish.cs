using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PunchFinish : StateMachineBehaviour
{ 
    public override void OnStateExit(Animator animator, AnimatorStateInfo stateInfo, int layerIndex)
    {
        animator.SetBool("isPunch", false);
        animator.SetBool("isWalk", true);
    }
}
