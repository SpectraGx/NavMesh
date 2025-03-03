using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CowStateMilk : State<CowAgent>
{
    public static CowStateMilk instance = new CowStateMilk();

    public override void Enter(CowAgent entity)
    {
        Debug.Log("La vaca esta siendo ordeñada");
        entity.agent.SetDestination(entity.milkArea.position);
    }

    public override void Execute(CowAgent entity)
    {
        entity.lactation -= 5f * Time.deltaTime;
        entity.hungry -= 2f * Time.deltaTime;
    }

    public override void Exit(CowAgent entity)
    {
        Debug.Log("La vaca deja de ser ordeñada");
    }
}
