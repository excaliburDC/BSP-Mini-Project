using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class project_cameraFollow : MonoBehaviour
{
    public float cameraMoveSpeed = 120.0f;
    public GameObject cameraFollowObj;
    Vector3 followPosition;
    public float clampAngle = 80.0f;
    public float inputSensitivity = 150.0f;
    public GameObject cameraObj;
    public GameObject playerObj;
    //distances of camera from plyer
    public float camDistX;
    public float camDistY;
    public float camDistZ;
    public float mouseX;
    public float mouseY;
    public float finalInputX;
    public float finalInputZ;
    public float smoothX;
    public float smoothY;
    private float rotX = 0.0f;
    private float rotY = 0.0f;

     void Start()
    {
        Vector3 rot = transform.localRotation.eulerAngles;
        rotX = rot.x;
        rotY = rot.y;
        
    }

    void Update()
    {
        finalInputX = Input.GetAxis("Mouse X");
        finalInputZ = Input.GetAxis("Mouse Y");
        rotY += finalInputX * inputSensitivity * Time.deltaTime;
        rotX += finalInputZ * inputSensitivity * Time.deltaTime;

        rotX = Mathf.Clamp(rotX, -clampAngle, clampAngle);
        Quaternion localRotation = Quaternion.Euler(rotX, rotY, 0.0f);
        transform.rotation = localRotation;

    }

    public void LateUpdate()
    {
        cameraUpdater();
    }

    void cameraUpdater()
    {
        Transform target = cameraFollowObj.transform;
        float step = cameraMoveSpeed * Time.deltaTime;
        transform.position = Vector3.MoveTowards(transform.position, target.position, step);

    }
}
