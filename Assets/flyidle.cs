using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class flyidle : StateMachineBehaviour
{
    float timer;
    Transform player;
    float ChaseRange = 100;
    // OnStateEnter is called when a transition starts and the state machine starts to evaluate this state
    override public void OnStateEnter(Animator animator, AnimatorStateInfo stateInfo, int layerIndex)
    {
        animator.SetBool("duoitheo", false);
        timer = 0;
        player = GameObject.FindGameObjectWithTag("Player").transform;
        Debug.Log("Entered Idle State");
    }

    // OnStateUpdate is called on each Update frame between OnStateEnter and OnStateExit callbacks
    override public void OnStateUpdate(Animator animator, AnimatorStateInfo stateInfo, int layerIndex)
    {

        float distance = Vector3.Distance(player.position, animator.transform.position);
        Debug.Log($"PET Idle State - Distance to player: {distance}");
        if (distance < ChaseRange)
        {
            Debug.Log("Player is within chase range. Setting isChasing to true.");
            animator.SetBool("duoitheo", true);
        }

    }

    // OnStateExit is called when a transition ends and the state machine finishes evaluating this state
    override public void OnStateExit(Animator animator, AnimatorStateInfo stateInfo, int layerIndex)
    {
        Debug.Log("Exiting Idle State");
    }
}
