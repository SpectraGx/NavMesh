using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CowEatState : State<CowAgent>
{
    public static CowEatState instance = null;
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
        Debug.Log("Vaca comiendo");
        entity.stateText.text = "Comiendo";

        // Comportamiento
        entity.hungry += 10f * Time.deltaTime;
        entity.stress -= 0.3f * Time.deltaTime;
        if (entity.hungry >= 77)
        {
            entity.lactation += 5f * Time.deltaTime;
        }
        else if (entity.hungry >= 40)
        {
            entity.lactation += 2f * Time.deltaTime;
        }

        // Cambio de estado
        if (entity.hungry >= 95)
        {
            entity.getFSM().SetCurrentState(CowIdleState.instance);
        }
        else if (entity.lactation >= 80)
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
