using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CowPlayState : State<CowAgent>
{
    public static CowPlayState instance = null;
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
    public override void Enter(CowAgent entity)
    {
    }

    public override void Execute(CowAgent entity)
    {
        Debug.Log("Vaca jugando");

        // Comportamiento
        entity.stress -= 5f * Time.deltaTime;
        entity.hungry -= 3f * Time.deltaTime;
        entity.resistance -= Time.deltaTime;
        if (entity.hungry >= 77)
        {
            entity.lactation += 3f * Time.deltaTime;
        }
        else if (entity.hungry >= 40)
        {
            entity.lactation += Time.deltaTime;
        }


        // Cambio de estado
        if (entity.hungry <= 40 && entity.stress >= 21 && entity.resistance >= 30)
        {
            entity.agent.destination = entity.grassArea.position;
            if (entity.distanceObjective <= 10)
            {
                entity.getFSM().SetCurrentState(CowEatState.instance);
            }
        }
        else if (entity.hungry >= 40 && entity.stress <= 21 && entity.resistance >= 30)
        {
            entity.getFSM().SetCurrentState(CowIdleState.instance);
        }
        else if (entity.hungry >= 40 && entity.stress >= 21 && entity.resistance <= 30)
        {
            entity.agent.destination = entity.barnArea.position;
            if (entity.distanceObjective <= 10)
            {
                entity.getFSM().SetCurrentState(CowSleepState.instance);
            }
        }
    }
}
