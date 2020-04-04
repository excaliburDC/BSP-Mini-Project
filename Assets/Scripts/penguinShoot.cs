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

    //public void setBallsDir()
    //{

    //    if (Physics.Raycast(spawnBalls.transform.position, spawnBalls.transform.forward, out hit, maxLength))
    //    {
    //        var drcn = hit.point - gameObject.transform.position;
    //        rotation = Quaternion.LookRotation(drcn);
    //        Debug.DrawRay(spawnBalls.transform.position, spawnBalls.transform.forward, Color.black);
    //    }
    //}
    //snowShoot
    //public void shootBalls()
    //{
    //    Vector3 camPos = cam.transform.position;
    //    camPos.y = camPos.y + 50.0f;
    //    if(Physics.Raycast(camPos, cam.transform.forward, out getPoint, 1000.0f))
    //    hitPoint =  getPoint.point;
    //    transform.rotation = Quaternion.LookRotation(spawnBalls.transform.forward);
    //    if(Physics.Raycast(spawnBalls.transform.position, hitPoint , out hit, 1000.0f ))
    //    {
    //        Debug.Log(hit.transform.name);
    //        Debug.DrawRay(spawnBalls.transform.position, cam.transform.forward,Color.black);

    //        //check if the ball hit the enemy
    //        if(hit.collider.CompareTag("Enemy"))
    //        {
    //            GameController.Instance.GiveDamage(playerattackDamage);
    //            if (GameController.Instance.currentEnemyHealth <= 0)
    //                Destroy(hit.collider.gameObject);
    //        }
    //    }

    //}


}
