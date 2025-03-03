using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CowStateEat : State <CowAgent>
{
    public static CowStateEat instance = new CowStateEat();

    public override void Enter(CowAgent entity)
    {
        Debug.Log("La vaca esta comiendo");
        entity.agent.SetDestination(entity.grassArea.position);
    }

    public override void Execute(CowAgent entity)
    {
        entity.hungry += 5f * Time.deltaTime;
        entity.stress -= 0.5f * Time.deltaTime;
    }

    public override void Exit(CowAgent entity)
    {
        Debug.Log("La vaca deja de comer");
    }
}
