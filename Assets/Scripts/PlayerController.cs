using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class PlayerController : MonoBehaviour
{
    [SerializeField] private Transform target;
    [SerializeField] private Transform target2;
    [SerializeField] private float timeSwitch = 5;
    private float time = 0;
    NavMeshAgent navMeshAgent;
    bool switchTarget = false;

    private void Start()
    {
        navMeshAgent = GetComponent<NavMeshAgent>();

        navMeshAgent.SetDestination(target.position);
    }

    private void Update()
    {
        if (time > timeSwitch)
        {
            if (switchTarget)
            {
                navMeshAgent.SetDestination(target.position);
                switchTarget = false;
            }
            else
            {
                navMeshAgent.SetDestination(target2.position);
                switchTarget = true;
            }
            time = 0;
        }
        time += Time.deltaTime;
    }
}
