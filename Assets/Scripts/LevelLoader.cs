﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class LevelLoader : SingletonManager<LevelLoader>
{
    public GameObject loadingScreen;
    public GameObject levelCompleteUI;
    public GameObject menuScreen;
    public Slider loadingBar;
    public Text loadCompleteText;
    public Animator transition;
    public float transitionTime = 1f;
    public static bool isLevelComplete = false;

    //public Animation loadingAnim;

    private void Awake()
    {
        DontDestroyOnLoad(gameObject);
    }



   public void LoadLevel()
   {
        if(menuScreen.activeInHierarchy)
            menuScreen.SetActive(false);

        AudioManager.Instance.FadePause("MenuSound");
        loadingScreen.SetActive(true);
        loadCompleteText.text = "";
        loadingBar.gameObject.SetActive(true);

        StartCoroutine(AsynchronousLoading(SceneManager.GetActiveScene().buildIndex+1));

       
        

       
        
   }

    public void LoadPreviousLevel()
    {
        loadingScreen.SetActive(true);
        loadCompleteText.text = "";
        loadingBar.gameObject.SetActive(true);

        StartCoroutine(AsynchronousLoading(0));

        if (!menuScreen.activeInHierarchy)
            menuScreen.SetActive(true);
    }

    public void LevelComplete()
    {
        AudioManager.Instance.Stop("GameSound");
        isLevelComplete = true;
        levelCompleteUI.SetActive(true);
        AudioManager.Instance.Play("LevelComplete");
        Time.timeScale = 0f;
        
    }

   private IEnumerator AsynchronousLoading(int sceneIndex)
   {
        yield return new WaitForSeconds(1f);

        AsyncOperation op = SceneManager.LoadSceneAsync(sceneIndex);

        op.allowSceneActivation = false;

        while (!op.isDone)
        {
            loadingBar.value = op.progress;
            
            
            // Check if the load has finished
            if (op.progress >= 0.9f)
            {
                loadingBar.value = 1f;
               
                loadingBar.gameObject.SetActive(false);
                //Change the Text to show the Scene is ready
                loadCompleteText.text = "Press SPACE to continue";
                //Wait to you press the space key to activate the Scene
             
                if (Input.GetKeyDown(KeyCode.Space))
                {
                    transition.SetTrigger("StartTransition");

                    yield return new WaitForSeconds(transitionTime);

                    loadingScreen.SetActive(false);

                    transition.SetTrigger("EndTransition");

                    //Activate the Scene
                    op.allowSceneActivation = true;

                    

                    

                }
            }
            Debug.Log(op.progress);

            yield return null;
        }
        
   }
}
