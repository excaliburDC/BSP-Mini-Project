using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class _PlayerMovement : MonoBehaviour
{
    private Rigidbody2D rb;
    private Vector3 Inp = Vector2.zero;
    private bool climb = false;

    public void Start()
    {
        rb = GetComponent<Rigidbody2D>();
    }

    public void Update()
    {
        Inp.x = Input.GetAxis("Horizontal");
        Vector2 In =  Vector2.zero;
        In.x = Inp.x;

        rb.velocity +=  In* 7f * Time.deltaTime;
        rb.transform.position += Inp * 12f * Time.deltaTime;

        if (climb == true)
            ladderclimb();
        else
            climb = false;

        
    }

    public void OnTriggerEnter2D(Collider2D collision)
    {


        if (collision.tag == "ladder")
        {
            climb = true;
            Debug.Log("Climbing");
        }
        else
            climb = false;
    }

    void ladderclimb()
    {
        Inp.y = Input.GetAxis("Vertical");
        Vector3 ladder = Vector3.zero;
        //rb.gravityScale = 0;
        ladder.y = 14 * Time.deltaTime;
        rb.transform.position += Inp * 7f * Time.deltaTime;
    }
}
