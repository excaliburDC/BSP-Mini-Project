using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class LevelLoader : MonoBehaviour
{
    public GameObject loadingScreen;
    public GameObject menuScreen;
    public Slider loadingBar;
    public Text loadCompleteText;
    //public Animation loadingAnim;

    private void Awake()
    {
        DontDestroyOnLoad(gameObject);
    }



    public void LoadLevel(int sceneIndex)
   {
        menuScreen.SetActive(false);
        loadingScreen.SetActive(true);

        StartCoroutine(AsynchronousLoading(sceneIndex));
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
                    //Activate the Scene
                    op.allowSceneActivation = true;
                }
            }
            Debug.Log(op.progress);

            yield return null;
        }
        
   }
}
