using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(menuName ="AI/State")]
public class State : ScriptableObject
{

    public List<Action> actions = new List<Action>();
    public List<Transitions> transitions = new List<Transitions>();
    public Color sceneGizmoColor = Color.grey;

    public void UpdateState(EnemyStateController controller)
    {
        DoActions(controller);
        CheckTransitions(controller);
    }

    private void DoActions(EnemyStateController controller)
    {
        for (int i = 0; i < actions.Count; i++)
        {
            actions[i].EnemyAction(controller);
        }
    }

    private void CheckTransitions(EnemyStateController controller)
    {
        foreach (Transitions t in transitions)
        {
            bool decisionSucceeded = t.aiDecision.Decide(controller);

            if(decisionSucceeded)
            {
                controller.TransitionToState(t.trueState);
            }
            else
            {
                controller.TransitionToState(t.falseState);
            }
        }
    }
}
