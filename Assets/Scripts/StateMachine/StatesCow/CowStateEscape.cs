using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CowStateEscape : State<CowAgent>
{
    public static CowStateEscape instance = new CowStateEscape();

    public override void Enter(CowAgent entity)
    {
        Debug.Log("La vaca esta escapando");
        entity.agent.speed = 6f;
        entity.agent.SetDestination(entity.safeArea.position);
    }

    public override void Execute(CowAgent entity)
    {
        entity.stress += 5f * Time.deltaTime;
        entity.resistance -= 5f * Time.deltaTime;
    }

    public override void Exit(CowAgent entity)
    {
        Debug.Log("La vaca deja de escapar");
        entity.agent.speed = 5f;
    }
}
