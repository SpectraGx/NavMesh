using UnityEngine;
using UnityEngine.AI;
using System.Collections;
using System.Collections.Generic;

public class NPCController : MonoBehaviour
{
    enum NPCState { Idle, ScaredByEvent, ScaredByOther }

    public float detectionRadius = 10f;
    public float panicRadius = 20f;
    public float fleeDistance = 10f;
    public float awarenessRadius = 15f;
    public LayerMask npcLayer;
    public float checkOtherNPCsInterval = 2f;

    private NavMeshAgent agent;
    private NPCState currentState = NPCState.Idle;
    private Vector3 currentTarget;
    private Coroutine stateChecker;

    void Start()
    {
        agent = GetComponent<NavMeshAgent>();
        PickNewTarget();
        EventManager.OnExplosionEvent += OnExplosion;
        stateChecker = StartCoroutine(CheckForScaredNPCs());
    }

    void OnDestroy()
    {
        EventManager.OnExplosionEvent -= OnExplosion;
    }

    void Update()
    {
        if (currentState == NPCState.Idle && agent.remainingDistance < 0.5f)
        {
            PickNewTarget();
        }
    }

    void PickNewTarget()
    {
        currentTarget = CityTargetsManager.Instance.GetRandomTarget();
        agent.SetDestination(currentTarget);
    }

    void OnExplosion(Vector3 explosionPos)
    {
        float dist = Vector3.Distance(transform.position, explosionPos);

        if (dist < detectionRadius)
        {
            FleeFrom(explosionPos);
            currentState = NPCState.ScaredByEvent;
        }
        else if (dist < panicRadius)
        {
            currentState = NPCState.Idle;
        }
    }

    void FleeFrom(Vector3 position)
    {
        Vector3 fleeDirection = (transform.position - position).normalized;
        Vector3 fleeTarget = transform.position + fleeDirection * fleeDistance;

        NavMeshHit hit;
        if (NavMesh.SamplePosition(fleeTarget, out hit, 10f, NavMesh.AllAreas))
        {
            agent.SetDestination(hit.position);
        }
    }

    IEnumerator CheckForScaredNPCs()
    {
        WaitForSeconds wait = new WaitForSeconds(checkOtherNPCsInterval);

        while (true)
        {
            if (currentState == NPCState.Idle)
            {
                Collider[] others = Physics.OverlapSphere(transform.position, awarenessRadius, npcLayer);
                foreach (var other in others)
                {
                    NPCController npc = other.GetComponent<NPCController>();
                    if (npc != null && (npc.currentState == NPCState.ScaredByEvent || npc.currentState == NPCState.ScaredByOther))
                    {
                        FleeFrom(npc.transform.position);
                        currentState = NPCState.ScaredByOther;
                        break;
                    }
                }
            }

            yield return wait;
        }
    }
}
