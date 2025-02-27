using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ag2_estadoPersigue : State<agenteDos>
{


    public static ag2_estadoPersigue instance = null;
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

    public override void Enter(agenteDos entidad)
    {
        entidad.agente.destination = entidad.objetivoPresa.position;
    }

    public override void Execute(agenteDos entidad)
    {
        entidad.energia -= Time.deltaTime*6.5f;
        float distanciaPierde = Vector3.Distance(entidad.transform.position, entidad.objetivoPresa.position);
        if( distanciaPierde > 9.5f)
        {
            entidad.getFSM().SetCurrentState(ag2_estadoPatrulla.instance);
        }

        entidad.agente.destination = entidad.objetivoPresa.position;

        if (entidad.energia < 30)
        {
            entidad.getFSM().ChangeState(ag2_Descansito.instance);
        }

                
    }
    
}
