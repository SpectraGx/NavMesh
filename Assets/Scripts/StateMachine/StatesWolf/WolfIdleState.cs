using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WolfIdleState : State<WolfAgent>
{
    public static WolfIdleState instance = null;
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
        Debug.Log("Lobo idle");

        // Comportamiento
        entity.resistance -= 2f * Time.deltaTime;
        entity.hungry -= 2f * Time.deltaTime;

        float distanceCow = Vector3.Distance(entity.cow.position, entity.transform.position);

        if (distanceCow < entity.distancePersecutor)
        {
            entity.getFSM().SetCurrentState(WolfPersecutorState.instance);
        }

        if (entity.resistance <= 20)
        {
            entity.getFSM().SetCurrentState(WolfSleepState.instance);
        }
    }
}
