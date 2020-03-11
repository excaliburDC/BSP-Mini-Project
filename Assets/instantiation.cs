using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class instantiation : MonoBehaviour
{
    private Transform lookDir;
    penguinShoot listUpdater;
    //Vector3 ballDir;
    public float ballSpeed = 15.0f;

    public void Start()
    {
        
        lookDir = GameObject.Find("Character").GetComponent<Transform>();
        listUpdater = GameObject.Find("Character").GetComponent<penguinShoot>();
        
    }
    //public void Awake()
    //{
        
    //}

    public void Update()
    {
        //transform.Translate(lookDir.forward * 10f );
        this.GetComponent<Rigidbody>().AddForce(lookDir.forward * ballSpeed, ForceMode.Impulse);
   }

    public void LateUpdate()
    {
        if (listUpdater.ballList.Count < 7)
        {
            listUpdater.addToQueue(gameObject);
        }
    }
}
