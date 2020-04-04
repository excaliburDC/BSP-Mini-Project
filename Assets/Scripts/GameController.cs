using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class GameController : SingletonManager<GameController>
{
    public List<EnemyStateController> stateController;
    public List<Transform> wayPoints;
    public int maxHealth = 100;
    public int currentHealth;
    public int currentEnemyHealth;
    public GameObject enemyHealthBar;
    public GameObject gameOverMenu;
    public GameObject minimap;
    public Slider playerHealthSlider;
    public bool isMainLevel = true;
    public static bool isGamePaused = false;
    public static bool isGameOver = false;


    public Slider enemyHealthSlider;



    // Start is called before the first frame update
    void Start()
    {
        gameOverMenu.SetActive(false);
        minimap.SetActive(true);
        playerHealthSlider.gameObject.SetActive(true);
        AudioManager.Instance.Play("GameSound");
        enemyHealthSlider = enemyHealthBar.GetComponentInChildren<Slider>();
        currentHealth = maxHealth;
        currentEnemyHealth = maxHealth;
        SetMaxHealth();
        
        
        stateController[0].SetupAI(true, wayPoints);
        stateController[1].SetupAI(true, wayPoints);
        stateController[2].SetupAI(true, wayPoints);
        stateController[3].SetupAI(true, wayPoints);
    }

   

    public void SetMaxHealth()
    {
        playerHealthSlider.maxValue = maxHealth;
        enemyHealthSlider.maxValue = maxHealth;
        playerHealthSlider.value = maxHealth;
        enemyHealthSlider.value = maxHealth;
        
    }

    public void SetHealth(int health)
    {
        playerHealthSlider.value = health;

    }

    public void GiveDamage(int damage)
    {
        currentEnemyHealth -= damage;
       
        if (currentEnemyHealth <= 0)
            currentEnemyHealth = 0;
        enemyHealthSlider.value = currentEnemyHealth;
        Debug.Log("Health: " + currentEnemyHealth);
        
    }

    public void TakeDamage(int damage)
    {
        currentHealth -= damage;
        if (currentHealth <= 0)
        {
            currentHealth = 0;
            Die();
        }
            
        SetHealth(currentHealth);


    }

    public void RestartLevel()
    {
        SceneManager.LoadSceneAsync(SceneManager.GetActiveScene().buildIndex);
        isGameOver = false;
        gameOverMenu.SetActive(false);
        minimap.SetActive(true);
        playerHealthSlider.gameObject.SetActive(true);

    }

    void Die()
    {
        AudioManager.Instance.Stop("GameSound");
        isGameOver = true;
        minimap.SetActive(false);
        playerHealthSlider.gameObject.SetActive(false);
        AudioManager.Instance.Play("GameOver");
        gameOverMenu.SetActive(true);
    }

    

    
}
