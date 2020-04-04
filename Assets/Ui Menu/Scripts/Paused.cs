using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Paused : MonoBehaviour
{
    public GameObject pauseMenu;
    public Animator pauseAnim;


    private void Start()
    {
        
    }



    // Update is called once per frame
    void Update()
    {
        if(Input.GetKeyDown(KeyCode.Escape) && GameController.Instance.isMainLevel )
        {
            if(GameController.isGamePaused)
            {
                Resume();
            }

            else
            {
                Pause();
            }
        }
    }

    public void Resume()
    {
        
        pauseAnim.SetBool("Open", false);
        Time.timeScale = 1f;
        AudioManager.Instance.Resume("GameSound");
        //pauseMenu.SetActive(false);
        
        GameController.isGamePaused = false;
    }

    public void Pause()
    {
        pauseMenu.SetActive(true);
        pauseAnim.SetBool("Open", true);
        Time.timeScale = 0f;
        AudioManager.Instance.Pause("GameSound");
        GameController.isGamePaused = true;
    }

    public void GoToMainMenu()
    {
        pauseAnim.SetBool("Open", false);
        pauseMenu.SetActive(false);
        LevelLoader.Instance.LoadPreviousLevel();
    }

    
}
