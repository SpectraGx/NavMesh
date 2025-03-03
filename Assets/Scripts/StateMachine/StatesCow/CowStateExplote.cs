using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CowStateExplote : State<CowAgent>
{
    public static CowStateExplote instance = new CowStateExplote();

    public override void Enter(CowAgent entity)
    {
        Debug.Log("La vaca va a explotar");
        Destroy(entity.gameObject);
    }

    public override void Execute(CowAgent entity)
    {
    }

    public override void Exit(CowAgent entity)
    {
        Debug.Log("La vaca ha explotado");
    }
}
