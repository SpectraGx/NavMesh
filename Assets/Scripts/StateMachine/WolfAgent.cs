using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class WolfAgent : MonoBehaviour
{
    [Header("Wolf Settings")]
    public float distancePersecutor = 8f;
    public float hungry = 100f;
    public float resistance = 100f;

    [Header("Wolf NavMesh")]
    public NavMeshAgent agent;

    [Header("Wolf State Machine")]
    StateMachine<WolfAgent> stateMachine;

    [Header("Cow")]
    public Transform cow;


    // Start is called before the first frame update
    void Start()
    {
        agent = GetComponent<NavMeshAgent>();
        //agente.destination = objetivos[0].position;

        stateMachine = new StateMachine<WolfAgent>(this);
        stateMachine.SetCurrentState(WolfIdleState.instance);
    }

    // Update is called once per frame
    void Update()
    {

    }

    private void FixedUpdate()
    {
        stateMachine.Updating();
    }

    public StateMachine<WolfAgent> getFSM()
    {
        return stateMachine;
    }
}
