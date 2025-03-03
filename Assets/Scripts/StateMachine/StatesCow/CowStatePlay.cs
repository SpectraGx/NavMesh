using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CowStatePlay : State<CowAgent>
{
    public static CowStatePlay instance = new CowStatePlay();

    public override void Enter(CowAgent entity)
    {
        Debug.Log("La vaca esta jugando");
        entity.agent.SetDestination(entity.playArea.position);
    }

    public override void Execute(CowAgent entity)
    {
        entity.stress -= 5f * Time.deltaTime;
        entity.hungry -= 2f * Time.deltaTime;
        entity.resistance -= 3f * Time.deltaTime;
    }

    public override void Exit(CowAgent entity)
    {
        Debug.Log("La vaca deja de jugar");
    }
}
