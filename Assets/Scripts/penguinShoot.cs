using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class penguinShoot : MonoBehaviour
{
    public GameObject spawnBalls;
    public GameObject ballPrefab;
    public Queue<GameObject> ballList = new Queue<GameObject>();
   
    private void createObjects()
    {
        for(int i = 0; i<10; i++)
        {
            var newObj = Instantiate(ballPrefab,transform.position, Quaternion.identity);
            newObj.SetActive(false);
            ballList.Enqueue(newObj);
        }
    }

    public void Start()
    {
        createObjects();
    }

    public void addToQueue(GameObject newObj)
    {
        newObj.SetActive(false);
            ballList.Enqueue(newObj);
    }

    public void Update()
    {
        if(Input.GetKeyDown(KeyCode.Mouse0))
        {
            var spawned = ballList.Dequeue();
            spawned.transform.position = spawnBalls.transform.position;
            spawned.SetActive(true);
        }
    }
}
