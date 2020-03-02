using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class StoryManager : SingletonManager<StoryManager>
{

    private Queue<string> sentences;

    // Start is called before the first frame update
    void Start()
    {
        sentences = new Queue<string>();
    }

    public void StartStory(Story story)
    {
        Debug.Log("Starting conversation...");
        Debug.Log(story.sentences[0]);
    }

}

    
