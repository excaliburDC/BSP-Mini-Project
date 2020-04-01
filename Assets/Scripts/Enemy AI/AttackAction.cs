using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu (menuName = "AI/Actions/Attack")]
public class AttackAction : Action
{
    public override void EnemyAction(EnemyStateController controller)
    {
        Attack(controller);
    }

    private void Attack(EnemyStateController controller)
    {
        RaycastHit hit;

        Debug.DrawRay(controller.eyes.position, controller.eyes.forward.normalized * controller.enemyStats.attackRange, Color.red);

        if (Physics.SphereCast(controller.eyes.position, controller.enemyStats.lookSphereCastRadius, controller.eyes.forward,
           out hit, controller.enemyStats.attackRange) && hit.collider.CompareTag("Player")) 
        {
            if(controller.CheckIfTimeElapsed(controller.enemyStats.attackRate))
            {
                Debug.Log("Enemy Attacks...");
                controller.enemyAnim.SetTrigger("Attack");
                GameController.Instance.TakeDamage(controller.enemyStats.attackDamage);
            }
        }
    }
}
