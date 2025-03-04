using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;
using Unity.UI;
using TMPro;

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

    [Header("Wolf enemy")]
    public float distanceEscape = 5f;
    public Transform wolf;

    [Header("Cow UI")]
    public TextMeshProUGUI stateText;

    [Header("VFX")]
    public GameObject exploteVFX;


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
