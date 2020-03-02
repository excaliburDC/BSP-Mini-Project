using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class LevelLoader : MonoBehaviour
{
    public GameObject loadingScreen;
    public Slider loadingBar;

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
        AsyncOperation op = SceneManager.LoadSceneAsync(sceneIndex);

        loadingScreen.SetActive(true);

        while(!op.isDone)
        {
            float progress = Mathf.Clamp01(op.progress / 0.9f);
            loadingBar.value = progress;
            Debug.Log(progress);
            yield return null;
        }
   }
}
