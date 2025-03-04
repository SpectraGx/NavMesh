using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CowIdleState : State<CowAgent>
{
    public static CowIdleState instance = null;
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
        Debug.Log("Vaca en estado Idle");
        entity.stateText.text = "Idle";


        // Comportamiento
        entity.hungry -= 3f * Time.deltaTime;
        entity.stress += Time.deltaTime;
        if (entity.hungry >= 77)
        {
            entity.lactation += 3f * Time.deltaTime;
        }
        else if (entity.hungry >= 40)
        {
            entity.lactation += Time.deltaTime;
        }

        // Cambio de estado
        if (entity.hungry <= 30 && entity.stress <= 70 && entity.lactation <= 80)
        {
            entity.agent.destination = entity.grassArea.position;
            if (entity.distanceObjective <= 5)
            {
                entity.getFSM().SetCurrentState(CowEatState.instance);
            }
        }
        else if (entity.hungry >= 30 && entity.stress >= 70 && entity.lactation <= 80)
        {
            entity.agent.destination = entity.playArea.position;
            if (entity.distanceObjective <= 10)
            {
                entity.getFSM().SetCurrentState(CowPlayState.instance);
            }
        }
        else if (entity.hungry >= 30 && entity.stress <= 70 && entity.lactation >= 80)
        {
            entity.agent.destination = entity.milkArea.position;
            if (entity.distanceObjective <= 10)
            {
                entity.getFSM().SetCurrentState(CowMilkState.instance);
            }
        }

        float distance = Vector3.Distance(entity.wolf.position, entity.transform.position);
        if (distance < entity.distanceEscape)
        {
            entity.getFSM().SetCurrentState(CowEscapeState.instance);
        }
    }
}
