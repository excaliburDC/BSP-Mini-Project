using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Movements_tilemap : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        Vector3 mvmnts = Vector2.up;
        Vector3 mvmnts_ = Vector2.right;
        if(Input.GetKey(KeyCode.UpArrow))
        {
            transform.position += mvmnts * 12 * Time.deltaTime; 
        }
        if (Input.GetKey(KeyCode.DownArrow))
        {
            transform.position -= mvmnts * 12 * Time.deltaTime;
        }
        if (Input.GetKey(KeyCode.RightArrow))
        {
            transform.position += mvmnts_ * 12 * Time.deltaTime;
        }
        if (Input.GetKey(KeyCode.LeftArrow))
        {
            transform.position -= mvmnts_ * 12 * Time.deltaTime;
        }
    }
}
