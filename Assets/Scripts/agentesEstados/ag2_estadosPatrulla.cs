using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting.Dependencies.Sqlite;
using UnityEngine;

public class ag2_estadoPatrulla : State<agenteDos>
{
    int idxObj;

    public static ag2_estadoPatrulla instance = null;
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
        int idxObj = 0;
        Debug.Log("agente2 patrulla");
        entidad.agente.destination = entidad.objetivos[idxObj].position;

    }

    public override void Execute(agenteDos entidad)
    {
        entidad.energia-= Time.deltaTime*3f;
        float distanciaObj = Vector3.Distance(entidad.transform.position, entidad.objetivos[idxObj].position);
        if (distanciaObj < 1.2)
        {
            idxObj++;
            if (idxObj > 3)
            {
                idxObj = 0;
            }
            

        }
        entidad.agente.destination = entidad.objetivos[idxObj].position;

        float distanciaPresa = Vector3.Distance(entidad.transform.position, entidad.objetivoPresa.position);
        if(distanciaPresa < entidad.distanciaPersigue)
        {
            entidad.getFSM().SetCurrentState(ag2_estadoPersigue.instance);
        }

        if(entidad.energia < 22f)
        {
            entidad.getFSM().ChangeState(ag2_Descansito.instance);
        }
             

    }
}