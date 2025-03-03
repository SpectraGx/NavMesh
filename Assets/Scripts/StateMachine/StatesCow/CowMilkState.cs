using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CowMilkState : State<CowAgent>
{
    public static CowMilkState instance = null;
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
        Debug.Log("Ordeñando vaca");

        // Comportamiento
        entity.lactation -= Time.deltaTime;
        entity.hungry -= 2f * Time.deltaTime;

        // Cambio de estado
        if (entity.lactation <= 30)
        {
            entity.getFSM().SetCurrentState(CowIdleState.instance);
        }
        else if (entity.hungry <= 40)
        {
            entity.agent.destination = entity.grassArea.position;
            if (entity.distanceObjective <= 10)
            {
                entity.getFSM().SetCurrentState(CowEatState.instance);
            }
        }
    }
}
