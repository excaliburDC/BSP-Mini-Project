using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class GameController : SingletonManager<GameController>
{
    public List<EnemyStateController> stateController;
    public List<Transform> wayPoints;
    public int maxHealth = 100;
    public int currentHealth;
    public int currentEnemyHealth;
    public GameObject enemyHealthBar;
    public Slider playerHealthSlider;
    public bool isMainLevel = false;


    public Slider enemyHealthSlider;



    // Start is called before the first frame update
    void Start()
    {
        enemyHealthSlider = enemyHealthBar.GetComponentInChildren<Slider>();
        currentHealth = maxHealth;
        currentEnemyHealth = maxHealth;
        SetMaxHealth();
        
        
        stateController[0].SetupAI(true, wayPoints);
        stateController[1].SetupAI(true, wayPoints);
        stateController[2].SetupAI(true, wayPoints);
        stateController[3].SetupAI(true, wayPoints);
    }

    private void Update()
    {
        if(Input.GetKeyDown(KeyCode.Space))
        {
            TakeDamage(25);
        }
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
       
        if (currentEnemyHealth < 0)
            currentEnemyHealth = 0;
        enemyHealthSlider.value = currentEnemyHealth;
        Debug.Log("Health: " + currentEnemyHealth);
        
    }

    public void TakeDamage(int damage)
    {
        currentHealth -= damage;
        if (currentEnemyHealth < 0)
            currentEnemyHealth = 0;
        SetHealth(currentHealth);

    }
}
