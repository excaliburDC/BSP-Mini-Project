using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMovements : MonoBehaviour
{
    public GameObject Player;
    private Rigidbody rb;
    public Vector3 inp = Vector3.zero;
    // Start is called before the first frame update
    public void Start()
    {
        rb = Player.GetComponent<Rigidbody>();
    }

    public void Update()
    {
        if(Input.GetKeyDown(KeyCode.Space))
        { rb.AddForce(Vector2.up * 100 *Vector2.right * 100, ForceMode.Force); }

        inp.x = Input.GetAxis("Horizontal");
        inp.z = Input.GetAxis("Vertical");

        rb.transform.position += inp * 5* Time.deltaTime;
    }
}
