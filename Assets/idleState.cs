using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class idleState : StateMachineBehaviour
{
    float timer;
    List<Transform> players = new List<Transform>();
    float ChaseRange = 10;

    override public void OnStateEnter(Animator animator, AnimatorStateInfo stateInfo, int layerIndex)
    {
        animator.SetBool("isChasing", false);
        timer = 0;
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

    override public void OnStateUpdate(Animator animator, AnimatorStateInfo stateInfo, int layerIndex)
    {
        RemoveInactivePlayers();
        timer += Time.deltaTime;

        if (players.Count == 0)
        {
            TryFindPlayers();
        }

        if (timer > 5)
        {
            animator.SetBool("isPatrolling", true);
        }

        Transform closestPlayer = GetClosestPlayer(animator);
        if (closestPlayer != null)
        {
            float distance = Vector3.Distance(closestPlayer.position, animator.transform.position);
            if (distance < ChaseRange)
            {
                animator.SetBool("isChasing", true);
            }
        }
    }

    override public void OnStateExit(Animator animator, AnimatorStateInfo stateInfo, int layerIndex)
    {
        Debug.Log("Exiting Idle State");
    }
}
