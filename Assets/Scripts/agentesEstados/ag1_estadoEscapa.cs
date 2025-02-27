using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public class ag1_estadoEscapa : State<agenteUno>
{


    public static ag1_estadoEscapa instance = null;
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

    public override void Enter(agenteUno entidad)
    {
        Debug.Log("entra Edo Escape");


    }

    public override void Execute(agenteUno entidad)
    {
        float distancia = Vector3.Distance(entidad.amenaza.position, entidad.transform.position);

        if( distancia < entidad.distanciaEscape)
        {
            entidad.agente.destination = entidad.objetivoSeguro.position;
        }

        float zonaSeguraDis = Vector3.Distance(entidad.objetivoSeguro.position, entidad.transform.position);
        if(zonaSeguraDis < 1.1f || distancia > 12f)
        {
            entidad.getFSM().SetCurrentState(ag1_estadoPatrulla.instance);
        }
        


    }



}
