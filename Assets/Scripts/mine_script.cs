using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class mine_script : MonoBehaviour
{
    [SerializeField] GameObject bullet;
    [SerializeField] float bullet_lifetime = 0.2f;
    System.Random rand = new System.Random();

    Vector3 random_velocity(float speed = 0.5f){
        float range = (float)rand.NextDouble() * (1.5f - 0.5f) + 0.5f;
        int angle_deg = rand.Next(0, 360);
        float angle_rad = angle_deg * (float)(Math.PI / 180);
        return new Vector3(Mathf.Sin(angle_rad), Mathf.Cos(angle_rad), 0f) * speed * range;
    }

    void OnCollisionEnter2D(Collision2D other) {
        for (int i = 0; i < 21; i++){
            GameObject new_bullet = Instantiate(bullet, transform.position, Quaternion.Euler(random_velocity(150f)));
            Destroy(new_bullet, bullet_lifetime);
        }
        Destroy(gameObject);
        
    }

    // Start is called before the first frame update
    void Start()
    {
        GetComponent<Rigidbody2D>().velocity = transform.up * 25;
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
