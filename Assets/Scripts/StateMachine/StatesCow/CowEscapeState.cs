using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CowEscapeState : State<CowAgent>
{
    public static CowEscapeState instance = null;
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
        Debug.Log("Vaca escapando");

        // Comportamiento
        entity.stress += 5f * Time.deltaTime;
        entity.resistance -= 5f * Time.deltaTime;
        entity.hungry -= 2f * Time.deltaTime;

        // Cambio de estado
        if (entity.stress >= 95)
        {
            entity.getFSM().SetCurrentState(CowExploteState.instance);
        }
        else if (entity.stress >= 60 && entity.hungry <= 50)
        {
            entity.getFSM().SetCurrentState(CowExploteState.instance);
        }
    }
}
