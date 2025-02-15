using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class NpcMovement : MonoBehaviour
{
    [SerializeField] private Transform[] destinations;
    [SerializeField] private Transform currentDestination;
    private NavMeshAgent agent;

    void Start()
    {
        agent = GetComponent<NavMeshAgent>();
        MoveToRandomDestination();
    }

    void Update()
    {
        if (agent.remainingDistance < 0.5f && !agent.pathPending)
        {
            MoveToRandomDestination();
        }
    }

    void MoveToRandomDestination()
    {
        Transform randomPoint = destinations[Random.Range(0, destinations.Length)];
        currentDestination = randomPoint;
        agent.SetDestination(randomPoint.position);
    }
}
