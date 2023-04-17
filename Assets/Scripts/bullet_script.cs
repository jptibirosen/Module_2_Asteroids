using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class bullet_script : MonoBehaviour
{

    [SerializeField] float thrust = 100f;
    [SerializeField] float speed_limit = 50f;
    


    void move_forward_with_thrust(){
        Rigidbody2D rigid_2D = gameObject.GetComponent<Rigidbody2D>();
        if (rigid_2D.velocity.magnitude < speed_limit){
            rigid_2D.AddForce(transform.up * thrust);
        }
    }

    void move_forward(){
        Rigidbody2D rigid_2D = gameObject.GetComponent<Rigidbody2D>();
        rigid_2D.velocity = transform.up * speed_limit;
    }

    void OnCollisionEnter2D(Collision2D crash) {
        Destroy(gameObject);
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
