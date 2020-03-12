using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(menuName = "AI/Decisions/Scan")]
public class ScanDecision : AIDecision
{
    public override bool Decide(EnemyStateController controller)
    {
        bool noEnemyInSight = Scan(controller);

        return noEnemyInSight;
    }

    private bool Scan(EnemyStateController controller)
    {
       // Vector3 tempScanPos = new Vector3(Random.Range(-1f, 1f), Random.Range(-1f, 1f), Random.Range(-1f, 1f));

        controller.agent.isStopped = true;

       // controller.transform.Translate(controller.transform.position + tempScanPos * controller.enemyStats.moveSpeed * Time.deltaTime);

        return controller.CheckIfTimeElapsed(controller.enemyStats.searchDuration);
    }
}
