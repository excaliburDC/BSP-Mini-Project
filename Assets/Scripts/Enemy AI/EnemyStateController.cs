using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class EnemyStateController : MonoBehaviour
{
    public State currentState;
    public EnemyStats enemyStats;
    public Transform eyes;
    public State remainingState;
    
    
    [HideInInspector] public NavMeshAgent agent;
    [HideInInspector] public Animator enemyAnim;
    [HideInInspector] public List<Transform> wayPointsList;
    [HideInInspector] public Transform chaseTarget;
    [HideInInspector] public int nextWayPoint;
    [HideInInspector] public float stateTimeElapsed;

   

    private bool aiActive;

    private void Awake()
    {
        agent = GetComponent<NavMeshAgent>();
        enemyAnim = GetComponent<Animator>();
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

    public void TransitionToState(State nextState)
    {
        if(nextState!=remainingState)
        {
            currentState = nextState;
            OnExitState();
        }
    }

    public bool CheckIfTimeElapsed(float duration)
    {
        stateTimeElapsed += Time.deltaTime;
        return (stateTimeElapsed >= duration);
    }

    public void OnExitState()
    {
        stateTimeElapsed = 0;
    }

    private void OnDrawGizmos()
    {
        if(currentState != null && eyes != null)
        {
            Gizmos.color = currentState.sceneGizmoColor;
            Gizmos.DrawWireSphere(eyes.position, enemyStats.lookSphereCastRadius);
        }
    }


}
