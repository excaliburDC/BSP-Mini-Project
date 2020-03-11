using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class EnemyStateController : MonoBehaviour
{
    public State currentState;

    [HideInInspector] public NavMeshAgent agent;
    [HideInInspector] public List<Transform> wayPointsList;

    private bool aiActive;

    private void Awake()
    {
        agent = GetComponent<NavMeshAgent>();
    }

    private void Update()
    {
        if (!aiActive)
            return;

        currentState.UpdateState(this);
    }

    public void SetupAI(bool activateAI,List<Transform> wayPoints)
    {
        wayPointsList = wayPoints;
        aiActive = activateAI;

        if(aiActive)
        {
            agent.enabled = true;
        }
        else
        {
            agent.enabled = false;
        }
    }
}
