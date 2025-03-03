using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CowStateIdle : State<CowAgent>
{
    public static CowStateIdle instance = new CowStateIdle();

    public override void Enter(CowAgent _owner)
    {
        Debug.Log("La vaca esta en Idle");
    }

    public override void Execute(CowAgent _owner)
    {
        Debug.Log("La vaca esta ejecutando Idle");
        _owner.hungry -= 3f * Time.deltaTime;
        _owner.stress += Time.deltaTime;
    }

    public override void Exit(CowAgent _owner)
    {
        Debug.Log("La vaca sale de Idle");
    }
}

