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
    

    public void Update()
    {
        //SnowBalls


        if (Input.GetKeyDown(KeyCode.Mouse0))
        {
            shootBalls();
            var spawned = ballList.Dequeue();
            spawned.transform.position = spawnBalls.transform.position;
            spawned.SetActive(true);
            
           // Invoke("shootBalls", 1f);
        }
       
    }
    //Object Pooling
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
    //snowShoot
    public void shootBalls()
    {
        Vector3 camPos = cam.transform.position;
        camPos.y = camPos.y + 50.0f;
        if(Physics.Raycast(camPos, cam.transform.forward, out getPoint, 1000.0f))
        hitPoint =  getPoint.point;

        if(Physics.Raycast(spawnBalls.transform.position, hitPoint , out hit, 1000.0f ))
        {
            Debug.Log(hit.transform.name);
            Debug.DrawRay(spawnBalls.transform.position, cam.transform.forward,Color.black);
        }

    }

   
}
