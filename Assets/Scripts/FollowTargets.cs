using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class FollowTargets : MonoBehaviour
{
    [SerializeField] private List<Transform> targets;
    private List<Transform> availableTargets = new List<Transform>();
    private Transform currentTarget;
    [SerializeField] private NavMeshAgent agent;


    void Start()
    {
        availableTargets.AddRange(targets);
        SetNewRandomTarget();
    }

    void Update()
    {
        if (agent.remainingDistance < 0.5f && !agent.pathPending)
        {
            availableTargets.Remove(currentTarget);

            if (availableTargets.Count == 0)
            {
                Debug.Log("No hay mas targets, reseteando");
                availableTargets.AddRange(targets);
            }
            SetNewRandomTarget();
        }
    }

    void SetNewRandomTarget()
    {
        int randomIndex = Random.Range(0, availableTargets.Count);
        currentTarget = availableTargets[randomIndex];
        agent.SetDestination(currentTarget.position);
    }
}
