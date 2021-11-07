using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MainCharPunchFinish : StateMachineBehaviour
{
    public override void OnStateExit(Animator animator, AnimatorStateInfo stateInfo, int layerIndex)
    {
        animator.SetBool("isAttack", false);
        animator.SetBool("isRunning", true);
    }
}
