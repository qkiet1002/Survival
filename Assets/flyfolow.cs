using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class flyfolow : StateMachineBehaviour
{
    NavMeshAgent agent;
    Transform player;
    //float ChaseRange = 15;
    // OnStateEnter is called when a transition starts and the state machine starts to evaluate this state
    override public void OnStateEnter(Animator animator, AnimatorStateInfo stateInfo, int layerIndex)
    {
        // animator.SetBool("isChasing", false);
        agent = animator.GetComponent<NavMeshAgent>();
        player = GameObject.FindGameObjectWithTag("Player").transform;
        agent.speed = 6f;
        Debug.Log("Entered Chase State");
    }

    //OnStateUpdate is called on each Update frame between OnStateEnter and OnStateExit callbacks
    override public void OnStateUpdate(Animator animator, AnimatorStateInfo stateInfo, int layerIndex)
    {
        agent.SetDestination(player.position);
        //animator.SetBool("isChasing", true);

        float distance = Vector3.Distance(player.position, animator.transform.position);
        if (distance < 3f)
        {
            Debug.Log("Player is within chase range. Setting isChasing to false.");
            animator.SetBool("dungim", true);
        }
    }
    //OnStateExit is called when a transition ends and the state machine finishes evaluating this state
    override public void OnStateExit(Animator animator, AnimatorStateInfo stateInfo, int layerIndex)
    {
        agent.SetDestination(animator.transform.position);
        Debug.Log("Exiting Chase State");
    }
}
