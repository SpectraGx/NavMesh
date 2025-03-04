using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CowSleepState : State<CowAgent>
{
    public static CowSleepState instance = null;
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
        Debug.Log("Vaca descansando");
        entity.stateText.text = "Durmiendo";


        // Comportamiento
        entity.resistance += 7f * Time.deltaTime;
        entity.hungry -= Time.deltaTime;
        entity.stress -= Time.deltaTime;
        if (entity.hungry >= 77)
        {
            entity.lactation += 3f * Time.deltaTime;
        }
        else if (entity.hungry >= 40)
        {
            entity.lactation += Time.deltaTime;
        }

        // Cambio de estado
        if (entity.resistance >= 85)
        {
            entity.getFSM().SetCurrentState(CowIdleState.instance);
        }
        else if (entity.hungry <= 30)
        {
            entity.agent.destination = entity.grassArea.position;
            if (entity.distanceObjective <= 10)
            {
                entity.getFSM().SetCurrentState(CowEatState.instance);
            }
        }
        else if (entity.lactation >= 80)
        {
            entity.agent.destination = entity.milkArea.position;
            if (entity.distanceObjective <= 10)
            {
                entity.getFSM().SetCurrentState(CowMilkState.instance);
            }
        }
        else if (entity.stress >= 60)
        {
            entity.agent.destination = entity.playArea.position;
            if (entity.distanceObjective <= 10)
            {
                entity.getFSM().SetCurrentState(CowPlayState.instance);
            }
        }

        float distance = Vector3.Distance(entity.wolf.position, entity.transform.position);
        if (distance > entity.distanceEscape && entity.resistance >= 50)
        {
            entity.getFSM().SetCurrentState(CowEscapeState.instance);
        }
    }
}
