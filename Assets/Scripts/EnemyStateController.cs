using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class EnemyStateController : MonoBehaviour
{
    public State currentState;
    public Transform eyes;
    
    [HideInInspector] public NavMeshAgent agent;
    [HideInInspector] public List<Transform> wayPointsList;
    [HideInInspector] public int nextWayPoint;

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

    private void OnDrawGizmos()
    {
        if(currentState != null && eyes != null)
        {
            Gizmos.color = currentState.sceneGizmoColor;
            //Gizmos.DrawWireSphere(eyes.position,);
        }
    }
}
