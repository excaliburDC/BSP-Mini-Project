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
        AudioManager.Instance.Resume("GameSound");
        //pauseMenu.SetActive(false);
        Time.timeScale = 1f;
        GameController.isGamePaused = false;
    }

    public void Pause()
    {
        pauseMenu.SetActive(true);
        pauseAnim.SetBool("Open", true);
        AudioManager.Instance.Pause("GameSound");
        Time.timeScale = 0f;
        GameController.isGamePaused = true;
    }

    public void Settings()
    {
        pauseAnim.SetBool("Open", false);
    }

    public void Back()
    {
        pauseAnim.SetBool("Open", true);
    }
}
