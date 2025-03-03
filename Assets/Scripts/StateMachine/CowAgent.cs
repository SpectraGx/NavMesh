using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class CowAgent : MonoBehaviour
{
    [Header("Cow Settings")]
    public float hungry = 100f;
    public float resistance = 100f;
    public float lactation = 30f;
    public float stress = 0f;
    public float distanceObjective = 0f;

    [Header("Cow Zones")]
    public Transform grassArea;
    public Transform playArea;
    public Transform barnArea;
    public Transform milkArea;

    [Header("Cow NavMesh")]
    public NavMeshAgent agent;

    [Header("Cow State Machine")]
    StateMachine<CowAgent> stateMachine;

    void Start()
    {
        agent = GetComponent<NavMeshAgent>();

        stateMachine = new StateMachine<CowAgent>(this);
        stateMachine.SetCurrentState(CowIdleState.instance);
    }

    void Update()
    {
        
    }

    void FixedUpdate()
    {
        stateMachine.Updating();
        distanceObjective = Vector3.Distance(agent.destination, transform.position);
    }

    public StateMachine<CowAgent> getFSM()
    {
        return stateMachine;
    }
}
