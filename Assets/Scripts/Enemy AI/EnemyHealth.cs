using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyHealth : MonoBehaviour
{
    public int maxEnemyHealth = 100;
    public int currentEnemyHealth;

    private void Start()
    {
        currentEnemyHealth = maxEnemyHealth;
    }

    private void Update()
    {
        if (Input.GetKeyDown(KeyCode.F))
        {
            GiveDamage(50);
        }
    }

    public void GiveDamage(int damage)
    {
        currentEnemyHealth -= damage;
        if (currentEnemyHealth < 0)
            currentEnemyHealth = 0;
        Debug.Log("Health: " + currentEnemyHealth);
       
    }

}
