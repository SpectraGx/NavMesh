using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WolfSleepState : State<WolfAgent>
{
    public static WolfSleepState instance = null;
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
    public override void Enter(WolfAgent entity)
    {
    }

    public override void Execute(WolfAgent entity)
    {
        Debug.Log("Descansando");

        entity.resistance += 3f * Time.deltaTime;
        entity.hungry += 2f * Time.deltaTime;

        if (entity.resistance >= 80)
        {
            entity.getFSM().SetCurrentState(WolfIdleState.instance);
        }
    }
}
