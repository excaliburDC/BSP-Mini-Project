using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class instantiation : MonoBehaviour
{
    private Transform lookDir;
    penguinShoot listUpdater;
    //Vector3 ballDir;
    public float ballSpeed = 15.0f;
    private Rigidbody rb;

    public void Start()
    {
        rb = GetComponent<Rigidbody>();
        lookDir = GameObject.Find("Character").GetComponent<Transform>();
        listUpdater = GameObject.Find("Character").GetComponent<penguinShoot>();
        
    }
  
    public void Update()
    {
        //transform.Translate(lookDir.forward * 10f );
        // this.GetComponent<Rigidbody>().AddForce(lookDir.forward * ballSpeed, ForceMode.Force);
      // transform.Translate(Vector3.MoveTowards(transform.position, listUpdater.hitPoint, 500f) * ballSpeed * Time.deltaTime, Space.World);
      //  rb.MovePosition(transform.position + (listUpdater.hitPoint * ballSpeed * Time.deltaTime));
   }
    public void FixedUpdate()
    {
        // transform.Translate(Vector3.MoveTowards(transform.position, listUpdater.hitPoint, 500f) * ballSpeed * Time.deltaTime, Space.World);
        rb.AddForce((listUpdater.spawnBalls.transform.position + listUpdater.hitPoint) * ballSpeed* Time.fixedDeltaTime); ;
    }
    public void LateUpdate()
    {
        if (listUpdater.ballList.Count < 7)
        {
            listUpdater.addToQueue(gameObject);
        }
    }
}
