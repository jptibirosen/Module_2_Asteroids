using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class railpellet_script : MonoBehaviour
{
    [SerializeField] float speed_limit = 250f;

    void move_forward(){
        Rigidbody2D rigid_2D = gameObject.GetComponent<Rigidbody2D>();
        rigid_2D.velocity = transform.up * speed_limit;
    }

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    void FixedUpdate() {
        move_forward();
    }
}
