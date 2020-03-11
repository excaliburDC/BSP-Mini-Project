using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(menuName ="AI/State")]
public class State : ScriptableObject
{

    public List<Action> actions = new List<Action>();
    public Color sceneGizmoColor = Color.grey;

    public void UpdateState(EnemyStateController controller)
    {
        DoActions(controller);
    }

    private void DoActions(EnemyStateController controller)
    {
        for (int i = 0; i < actions.Count; i++)
        {
            actions[i].EnemyAction(controller);
        }
    }
}
