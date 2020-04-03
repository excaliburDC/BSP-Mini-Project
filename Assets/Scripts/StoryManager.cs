using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class StoryManager : SingletonManager<StoryManager>
{

    private Queue<string> sentences;
    public Text storyText;


    // Start is called before the first frame update
    void Start()
    {
        sentences = new Queue<string>();
    }

    public void StartStory(Story story)
    {
        Debug.Log("Starting conversation...");
       // Debug.Log(story.sentences[0]);
       sentences.Clear();

        foreach (string sentence in story.sentences)
        {
            //Debug.Log(sentence);
            sentences.Enqueue(sentence);
        }
        DisplayNext();


    }

    public void DisplayNext()
    {

        Debug.Log(sentences.Count);
        if(sentences.Count==0)
        {
            EndStory();
            return;
        }

        
       string tempSentence = sentences.Dequeue();
       Debug.Log(tempSentence);

       StopAllCoroutines(); 
       StartCoroutine(StoryTextAnim(tempSentence));
    }



    private void EndStory()
    {
        Debug.Log("Story over...");
        LevelLoader.Instance.LoadLevel();
     

    }


    IEnumerator StoryTextAnim(string storySentence)
    {
        storyText.text = "";
        foreach (char letter in storySentence.ToCharArray())
        {
            storyText.text += letter;
            yield return null;
        }
    }
}

    
