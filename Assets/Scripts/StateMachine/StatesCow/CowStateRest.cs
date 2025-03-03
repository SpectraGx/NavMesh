using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CowStateRest : State<CowAgent>
{
    public static CowStateRest instance = new CowStateRest();
    
    public override void Enter(CowAgent entity)
    {
        Debug.Log("La vaca esta descansando");
        entity.agent.speed = 0.5f;
    }

    public override void Execute(CowAgent entity)
    {
        entity.agent.speed = 0.5f;
        entity.resistance += 8f * Time.deltaTime;
        entity.hungry -= 3f * Time.deltaTime;
    }

    public override void Exit(CowAgent entity)
    {
        Debug.Log("La vaca deja de descansar");
        entity.agent.speed = 5f;
    }
}
