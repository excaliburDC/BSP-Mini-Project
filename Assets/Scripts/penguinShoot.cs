using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class penguinShoot : MonoBehaviour
{
    public GameObject cam;
    public GameObject spawnBalls;
    public GameObject ballPrefab;
    public Queue<GameObject> ballList = new Queue<GameObject>();
    RaycastHit hit, getPoint;
    public Vector3 hitPoint;
    //public Quaternion rotation;
    public float maxLength;


    public int playerattackDamage = 50;


    public void Update()
    {
        //SnowBalls


        if (Input.GetKeyDown(KeyCode.Mouse0))
        {
            //shootBalls();
           
            var spawned = ballList.Dequeue();
            spawned.transform.position = spawnBalls.transform.position;
            //setBallsDir();
            spawned.SetActive(true);
            spawned.transform.rotation = spawnBalls.transform.rotation;
            
            // Invoke("shootBalls", 1f);
        }

    }
    //Object Pooling
    private void createObjects()
    {
        for (int i = 0; i < 10; i++)
        {
            var newObj = Instantiate(ballPrefab, transform.position, Quaternion.identity);
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

    


}
