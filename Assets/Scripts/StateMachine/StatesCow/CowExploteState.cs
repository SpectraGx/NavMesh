using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CowExploteState : State<CowAgent>
{
    public static CowExploteState instance = null;
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
        Debug.Log("Vaca explotando");
        Destroy(entity.gameObject);
    }

    public override void Execute(CowAgent entity)
    {
        Instantiate(entity.exploteVFX, entity.transform.position, Quaternion.identity);
    }
}
