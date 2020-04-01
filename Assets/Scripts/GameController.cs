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
    public GameObject healthBar;
    public Slider slider;
    public bool isMainLevel = false;


   
    // Start is called before the first frame update
    void Start()
    {
        
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
        slider.maxValue = maxHealth;
        slider.value = maxHealth;
    }

    public void SetHealth(int health)
    {
        slider.value = health;

    }

    public void GiveDamage(int damage)
    {
        currentEnemyHealth -= damage;
        Debug.Log("Health: " + currentEnemyHealth);
        if (currentEnemyHealth <= 0)
            Destroy(gameObject);
    }

    public void TakeDamage(int damage)
    {

        currentHealth -= damage;
        SetHealth(currentHealth);

    }
}
