using System.Collections;
using System.Collections.Generic;
using Assets.Scripts.Global;
using UnityEngine;

public class FadeInOutBehaviour : StateMachineBehaviour
{
    private static readonly int TextLifetimeTimer = Animator.StringToHash("textLifetimeTimer");
    private static readonly int FadeTimeExpired = Animator.StringToHash("fadeTimeExpired");

    // OnStateEnter is called when a transition starts and the state machine starts to evaluate this state
    public override void OnStateEnter(Animator animator, AnimatorStateInfo stateInfo, int layerIndex)
    {
        animator.SetBool(FadeTimeExpired, false);
    }

    // OnStateUpdate is called on each Update frame between OnStateEnter and OnStateExit callbacks
    //override public void OnStateUpdate(Animator animator, AnimatorStateInfo stateInfo, int layerIndex)
    //{
    //    
    //}

    //OnStateExit is called when a transition ends and the state machine finishes evaluating this state
    public override void OnStateExit(Animator animator, AnimatorStateInfo stateInfo, int layerIndex)
    {

        var hack = animator.GetComponent<CatFadingTextController>();
        hack.StartCoroutine(WaitForAnimationFadeTimer(animator));
    }

    private IEnumerator WaitForAnimationFadeTimer(Animator animator)
    {
        yield return new WaitForSeconds(animator.GetFloat(TextLifetimeTimer));
        animator.SetBool(FadeTimeExpired, true);
    }

    // OnStateMove is called right after Animator.OnAnimatorMove()
    //override public void OnStateMove(Animator animator, AnimatorStateInfo stateInfo, int layerIndex)
    //{
    //    // Implement code that processes and affects root motion
    //}

    // OnStateIK is called right after Animator.OnAnimatorIK()
    //override public void OnStateIK(Animator animator, AnimatorStateInfo stateInfo, int layerIndex)
    //{
    //    // Implement code that sets up animation IK (inverse kinematics)
    //}
}
