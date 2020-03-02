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

    private void Awake()
    {
        DontDestroyOnLoad(gameObject);
    }



    public void LoadLevel(int sceneIndex)
   {
        StartCoroutine(AsynchronousLoading(sceneIndex));
   }

   private IEnumerator AsynchronousLoading(int sceneIndex)
   {
        yield return new WaitForSeconds(5f);

        AsyncOperation op = SceneManager.LoadSceneAsync(sceneIndex);

        menuScreen.SetActive(false);
        loadingScreen.SetActive(true);
        

        while(!op.isDone)
        {
            loadingBar.value = op.progress;
            Debug.Log(op.progress);

            // Check if the load has finished
            if (op.progress >= 0.9f)
            {
                loadingBar.enabled = false;
                //Change the Text to show the Scene is ready
                loadCompleteText.text = "Press the space bar to continue";
                //Wait to you press the space key to activate the Scene
                if (Input.GetKeyDown(KeyCode.Space))
                    //Activate the Scene
                    op.allowSceneActivation = true;
            }

            yield return new WaitForSeconds(5f);
        }
   }
}
