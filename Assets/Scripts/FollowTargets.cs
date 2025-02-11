using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class FollowTargets : MonoBehaviour
{
    [Header("Targets")]
    [SerializeField] private Transform[] targets;
    NavMeshAgent navMeshAgent;
    bool switchTarget = false;

    void Start()
    {
        navMeshAgent = GetComponent<NavMeshAgent>();
        SetTarget(Random.Range(0, targets.Length));
    }

    void Update()
    {
        if (navMeshAgent.remainingDistance < 0.5f)
        {
            SetTarget(Random.Range(0, targets.Length));
        }
    }

    void EliminationTarget(int index)
    {
        Transform[] newTargets = new Transform[targets.Length - 1];
        for (int i = 0; i < targets.Length; i++)
        {
            if (i < index)
            {
                newTargets[i] = targets[i];
            }
            else if (i > index)
            {
                newTargets[i - 1] = targets[i];
            }
        }
        targets = newTargets;
    }

    public void SetTarget(int index)
    {
        navMeshAgent.SetDestination(targets[index].position);
    }
}
