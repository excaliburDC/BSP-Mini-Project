using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(menuName = "AI/Actions/Patrol")]
public class PatrolAction : Action
{
    public override void EnemyAction(EnemyStateController controller)
    {
        Patrol(controller);
    }

    private void Patrol(EnemyStateController controller)
    {
       // controller.enemyAnim.SetTrigger("Walk");
        controller.agent.destination = controller.wayPointsList[controller.nextWayPoint].position;
        controller.agent.isStopped = false;

        if(controller.agent.remainingDistance<=controller.agent.stoppingDistance && !controller.agent.pathPending)
        {
            controller.nextWayPoint = (controller.nextWayPoint + 1) % controller.wayPointsList.Count;
        }
    }
}
