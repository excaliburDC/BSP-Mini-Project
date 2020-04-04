using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class penguinMove : MonoBehaviour
{
    private Vector2 input;
    private Vector2 inputDirection;
   // public float speed = 7.0f;
    private float smoothSpeed = 0.2f;
    private float dampValue;
    Transform Cam;
    public void Start()
    {
        Cam = Camera.main.transform;
    }

    public void Update()
    {
        input = new Vector2(Input.GetAxisRaw("Horizontal"), Input.GetAxisRaw("Vertical"));
        inputDirection = input.normalized;

        if (inputDirection != Vector2.zero)
        {
            float targetRotation = Mathf.Atan2(inputDirection.x, inputDirection.y) * Mathf.Rad2Deg + Cam.eulerAngles.y;
            transform.eulerAngles = Vector3.up * Mathf.SmoothDampAngle(transform.eulerAngles.y, targetRotation, ref dampValue, smoothSpeed);
          
        }

    
        float speed = 7.0f * inputDirection.magnitude;
        transform.Translate(transform.forward * speed * Time.deltaTime, Space.World);
        

        if (GameController.isGameOver)
            Destroy(this.gameObject);

    


    }

    private void OnTriggerEnter(Collider col)
    {
        if(col.gameObject.tag=="ExitGate")
        {
            Debug.Log("LevelComplete");
            LevelLoader.Instance.LevelComplete();
        }
    }

   


}
