using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class large_as_script : MonoBehaviour
{
    [SerializeField] GameObject medium_as;
    [SerializeField] GameObject powerup;
    System.Random rand = new System.Random();


    Vector3 random_velocity(){  //should rewrite this function so it takes 'speed' as argument; more versatile
        float speed = 12f;
        float range = (float)rand.NextDouble() * (1.5f - 0.5f) + 0.5f;
        int angle_deg = rand.Next(0, 360);
        float angle_rad = angle_deg * (float)(Math.PI / 180);
        return new Vector3(Mathf.Sin(angle_rad), Mathf.Cos(angle_rad), 0f) * speed * range;
    }

    void spawn_medium_as(Vector3 velocity){
        GameObject new_as = Instantiate(medium_as, transform.position, transform.rotation);
        new_as.GetComponent<Rigidbody2D>().velocity = velocity;
    }

    void break_up(){
        List<int> break_distribution = new List<int> {2, 2, 2, 2, 2, 2, 3, 3, 3, 4};
        int number_of_asteroids = break_distribution[rand.Next(break_distribution.Count)];
        for (int i = 1; i <= number_of_asteroids; i++){
            spawn_medium_as(random_velocity());
        }
    }

    void spawn_powerup(){
        GameObject new_powerup = Instantiate(powerup, transform.position, transform.rotation);
        new_powerup.GetComponent<Rigidbody2D>().velocity = random_velocity() * 3 / 12;
    }

    void OnCollisionEnter2D(Collision2D crash) {
        break_up();
        spawn_powerup();
        GameObject.Find("score_board").GetComponent<Score_script>().the_score += 10;
        Destroy(gameObject);    
    }

    void OnTriggerEnter2D(Collider2D other) {
        break_up();
        spawn_powerup();
        GameObject.Find("score_board").GetComponent<Score_script>().the_score += 10;
        Destroy(gameObject); 
    }


    // Start is called before the first frame update
    void Start()
    {
        GetComponent<Rigidbody2D>().velocity = random_velocity() * 3 / 12;
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
