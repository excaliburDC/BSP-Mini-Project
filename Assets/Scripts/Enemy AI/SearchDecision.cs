using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(menuName = "AI/Decisions/Search")]
public class SearchDecision : AIDecision
{
    public override bool Decide(EnemyStateController controller)
    {
        bool targetVisible = Search(controller);

        return targetVisible;
    }

    private bool Search(EnemyStateController controller)
    {
        RaycastHit hit;

        Debug.DrawRay(controller.eyes.position, controller.eyes.forward.normalized * controller.enemyStats.lookRange, Color.red);

        //controller.enemyAnim.SetTrigger("Walk");
        if (Physics.SphereCast(controller.eyes.position, controller.enemyStats.lookSphereCastRadius, controller.eyes.forward,
           out hit, controller.enemyStats.lookRange) && hit.collider.CompareTag("Player"))
        {
            controller.enemyAnim.SetTrigger("Run");
            controller.chaseTarget = hit.transform;
            return true;
        }

        else
        {
            //controller.enemyAnim.SetTrigger("Walk");
            return false;
        }
            
    }
}
