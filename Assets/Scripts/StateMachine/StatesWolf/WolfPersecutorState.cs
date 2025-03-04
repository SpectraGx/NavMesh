using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WolfPersecutorState : State<WolfAgent>
{
    public static WolfPersecutorState instance = null;
    private void Awake()
    {
        if (instance == null)
            instance = this;
        else if (instance != this)
        {
            Destroy(this.gameObject);
        }
        DontDestroyOnLoad(this.gameObject);
    }
    public override void Enter(WolfAgent entity)
    {
    }

    public override void Execute(WolfAgent entity)
    {
        Debug.Log("Lobo cazando");

        entity.resistance -= 4f * Time.deltaTime;
        entity.hungry -= 3f * Time.deltaTime;
        entity.agent.destination = entity.cow.position;


        float distanceCow = Vector3.Distance(entity.cow.position, entity.transform.position);

        if (distanceCow > entity.distancePersecutor)
        {
            entity.getFSM().SetCurrentState(WolfIdleState.instance);
        }
        if (entity.resistance <= 20)
        {
            entity.getFSM().SetCurrentState(WolfSleepState.instance);
        }


    }
}
