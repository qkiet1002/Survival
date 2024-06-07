using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AttackState : StateMachineBehaviour
{
    List<Transform> players = new List<Transform>();
    // OnStateEnter is called when a transition starts and the state machine starts to evaluate this state
    override public void OnStateEnter(Animator animator, AnimatorStateInfo stateInfo, int layerIndex)
    {
        //player = GameObject.FindGameObjectWithTag("Player").transform;
        TryFindPlayers();
    }
    void TryFindPlayers()
    {
        players.Clear();
        GameObject[] playerObjects = GameObject.FindGameObjectsWithTag("Player");
        foreach (GameObject playerObject in playerObjects)
        {
            if (playerObject.activeInHierarchy)
            {
                players.Add(playerObject.transform);
            }
        }
    }
    void RemoveInactivePlayers()
    {
        players.RemoveAll(player => player == null || !player.gameObject.activeInHierarchy);
    }
    Transform GetClosestPlayer(Animator animator)
    {
        Transform closestPlayer = null;
        float shortestDistance = Mathf.Infinity;

        foreach (Transform player in players)
        {
            float distance = Vector3.Distance(player.position, animator.transform.position);
            if (distance < shortestDistance)
            {
                shortestDistance = distance;
                closestPlayer = player;
            }
        }

        return closestPlayer;
    }

    // OnStateUpdate is called on each Update frame between OnStateEnter and OnStateExit callbacks
    override public void OnStateUpdate(Animator animator, AnimatorStateInfo stateInfo, int layerIndex)
    {
        RemoveInactivePlayers();

        if (players.Count == 0)
        {
            TryFindPlayers();
        }
        Transform closestPlayer = GetClosestPlayer(animator);
        animator.transform.LookAt(closestPlayer);
        float distance = Vector3.Distance(closestPlayer.position, animator.transform.position);
        if (distance > 4f)
        {
            //Debug.Log("Player is within chase range. Setting isChasing to true.");
            animator.SetBool("isAttacking", false);
        }

    }

    // OnStateExit is called when a transition ends and the state machine finishes evaluating this state
    //override public void OnStateExit(Animator animator, AnimatorStateInfo stateInfo, int layerIndex)
    //{
    //    
    //}

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
