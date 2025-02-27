using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class agenteUno : MonoBehaviour
{

    public float distanciaEscape = 5f;

    public List<Transform> objetivos;

    public Transform amenaza;
    public Transform objetivoSeguro;

    public NavMeshAgent agente;

    StateMachine<agenteUno> maquinaEstados;

    // Start is called before the first frame update
    void Start()
    {
        agente = GetComponent<NavMeshAgent>();
        //agente.destination = objetivos[0].position;

        maquinaEstados = new StateMachine<agenteUno>(this);
        maquinaEstados.SetCurrentState(ag1_estadoPatrulla.instance);
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    private void FixedUpdate()
    {
        maquinaEstados.Updating();
    }

    public StateMachine<agenteUno> getFSM()
    {
        return maquinaEstados;
    }
}
