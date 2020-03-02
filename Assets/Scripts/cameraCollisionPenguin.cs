using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class cameraCollisionPenguin : MonoBehaviour
{
    public float minDistance = 1.0f;
    public float maxdistance = 7.0f;
    public float smoothing = 10.0f;
    Vector3 dollyDirection;
    public Vector3 dollyDirAdjusted;
    public float distance;
    public void Awake()
    {
        dollyDirection = transform.localPosition.normalized;
        distance = transform.localPosition.magnitude;
    }

    // Update is called once per frame
    void Update()
    {
        Vector3 desiredCameraPos = transform.parent.TransformPoint(dollyDirection * maxdistance);
        RaycastHit hit;

        if(Physics.Linecast(transform.parent.position, desiredCameraPos,out hit))
        {
            distance = Mathf.Clamp(hit.distance * 0.9f, minDistance, maxdistance);
        }
        else
        {
            distance = maxdistance;
        }
        transform.localPosition = Vector3.Lerp(transform.localPosition, dollyDirection * distance, Time.deltaTime * smoothing);

            }
}
