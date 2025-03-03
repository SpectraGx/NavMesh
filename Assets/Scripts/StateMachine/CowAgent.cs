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

    [Header("Cow Zones")]
    public Transform grassArea;
    public Transform playArea;
    public Transform barnArea;
    public Transform milkArea;
    public Transform safeArea;

    [Header("Cow NavMesh")]
    public NavMeshAgent agent;

    [Header("Cow State Machine")]
    StateMachine<CowAgent> fsm;
    private State<CowAgent> currentState;
    private float stateTimer = 0;

    void Start()
    {
        agent = GetComponent<NavMeshAgent>();
        agent.speed = 5f;

        fsm = new StateMachine<CowAgent>(this);

        fsm.SetCurrentState(CowStateIdle.instance);
        currentState = CowStateIdle.instance;

    }

    void Update()
    {
        fsm.Updating();
        CheckStateTransitions();
    }

    void CheckStateTransitions()
    {
        if (hungry < 30 && currentState != CowStateEat.instance)
        {
            ChangeState(CowStateEat.instance);
        }
        else if (stress > 70 && currentState != CowStatePlay.instance)
        {
            ChangeState(CowStatePlay.instance);
        }
        else if (lactation > 80 && currentState != CowStateMilk.instance)
        {
            ChangeState(CowStateMilk.instance);
        }
        else if (resistance < 30 && currentState != CowStateRest.instance)
        {
            ChangeState(CowStateRest.instance);
        }
        else if (currentState != CowStateIdle.instance && hungry >= 30 && stress <= 70 && lactation <= 80 && resistance >= 30)
        {
            ChangeState(CowStateIdle.instance);
        }
    }

    void ChangeState(State<CowAgent> newState)
    {
        currentState = newState;
        fsm.ChangeState(newState);
    }


}
