using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(menuName = "AI/Actions/Chase")]
public class ChaseAction : Action
{
    public override void EnemyAction(EnemyStateController controller)
    {
        Chase(controller);
    }

    private void Chase(EnemyStateController controller)
    {
        controller.agent.destination = controller.chaseTarget.position;
        controller.enemyAnim.SetTrigger("Run");
        controller.agent.isStopped = false;
    }
}
