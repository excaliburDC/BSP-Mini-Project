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
        input = new Vector2(Input.GetAxisRaw("Horizontal"), Input.GetAxisRaw("Vertical") );
        inputDirection = input.normalized;

        if (inputDirection != Vector2.zero)
        {
            float targetRotation = Mathf.Atan2(inputDirection.x, inputDirection.y) * Mathf.Rad2Deg + Cam.eulerAngles.y;
            transform.eulerAngles = Vector3.up * Mathf.SmoothDampAngle(transform.eulerAngles.y, targetRotation, ref dampValue, smoothSpeed);
            
        }

        //bool walk = Input.GetKey(KeyCode.UpArrow) ;
        //float speed = ((walk) ? (7.0f) : (0.0f))*inputDirection.magnitude;
        float speed = 7.0f * inputDirection.magnitude;
        transform.Translate(transform.forward * speed * Time.deltaTime, Space.World);


    }

    private void OnTriggerEnter(Collider col)
    {
        if(col.gameObject.tag=="ExitGate")
        {
            Debug.Log("LevelComplete");
            LevelLoader.Instance.LevelComplete();
        }
    }

    // private Rigidbody rb;
    // public float movementSpeed = 7.0f;
    // private Vector3 movementInput;
    // Transform cam;
    // float A = 2.0f, B = 4.0f;
    // void Start()
    // {
    //     rb = this.GetComponent<Rigidbody>();
    //     cam = Camera.main.transform;
    // }

    // void Update()
    // {
    //     movementInput.x = Input.GetAxis("Horizontal");
    //     movementInput.z = Input.GetAxis("Vertical");

    //     if (movementInput!=Vector3.zero)
    //     {
    //         rb.transform.position += movementInput * movementSpeed * Time.deltaTime;
    //     }
    //     float rot = cam.eulerAngles.y;
    //     transform.eulerAngles = Vector3.up * Mathf.SmoothDampAngle(transform.eulerAngles.y, rot, ref A, B, 12f) ;
    //}


}
