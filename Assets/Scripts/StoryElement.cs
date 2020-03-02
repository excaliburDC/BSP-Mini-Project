using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class StoryElement : MonoBehaviour
{
    public Story story;

    private void Start()
    {
        TriggerStory();
    }

    public void TriggerStory()
    {
        StoryManager.Instance.StartStory(story);
    }
}
