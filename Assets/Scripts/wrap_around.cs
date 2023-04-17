using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class wrap_around : MonoBehaviour
{

    void wrap(float x_boundary, float y_boundary){
        if (transform.position.x > x_boundary){
            transform.position += new Vector3(-2 * x_boundary, 0f, 0f);
        }
        if (transform.position.x < -x_boundary){
            transform.position += new Vector3(2 * x_boundary, 0f, 0f);
        }

        if (transform.position.y > y_boundary){
            transform.position += new Vector3(0f, -2 * y_boundary, 0f);
        }
        if (transform.position.y < -y_boundary){
            transform.position += new Vector3(0f, 2 * y_boundary, 0f);
        }
    }

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        wrap(48, 20);   //screen half-width and half-height
    }
}
