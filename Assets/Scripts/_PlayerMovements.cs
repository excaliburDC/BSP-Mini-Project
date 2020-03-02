using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class _PlayerMovements : MonoBehaviour
{
    public GameObject Player;
    private Rigidbody2D rb;
    public Vector3 inp = Vector3.zero;
    public float speed = 7f;
    // Start is called before the first frame update
    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Space))
        {
            rb.AddForce(Vector3.up*60);
        }

        inp.x = Input.GetAxis("Horizontal");
        inp.y = Input.GetAxis("Vertical");


        rb.transform.position += inp * speed * Time.deltaTime;
       // rb.transform.forward -= inp;
    }

    public void OnTriggerEnter2D(Collider2D other)
    {
        if (other.tag == "ladder")
        {
            if (Input.GetKey(KeyCode.UpArrow))
            {
                rb.transform.position += inp;
            }
        }
    }
}
