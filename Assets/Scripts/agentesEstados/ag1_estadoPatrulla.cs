using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting.Dependencies.Sqlite;
using UnityEngine;

public class ag1_estadoPatrulla : State<agenteUno>
{
    float tiempo;
    int idxObj;

    public static ag1_estadoPatrulla instance = null;
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
        Debug.Log("entra Patrulla Agente1");
        

    }

    public override void Execute(agenteUno entidad)
    {

        if (tiempo > 5f)
        {
            tiempo = 0;
            idxObj++;
            if(idxObj >= 4)
            {
                idxObj = 0;
            }
            entidad.agente.destination = entidad.objetivos[idxObj].position;
        }
        tiempo += Time.deltaTime;

        float distanciaAmenza = Vector3.Distance(entidad.transform.position, entidad.amenaza.position);
        if (distanciaAmenza < entidad.distanciaEscape)
        {
            entidad.getFSM().SetCurrentState(ag1_estadoEscapa.instance);
        }              

    }
}