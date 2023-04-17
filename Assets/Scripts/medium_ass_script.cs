using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class medium_ass_script : MonoBehaviour
{
    [SerializeField] GameObject small_as;
    System.Random rand = new System.Random();


    Vector3 random_velocity(){
        float speed = 20f;
        float range = (float)rand.NextDouble() * (1.5f - 0.5f) + 0.5f;
        int angle_deg = rand.Next(0, 360);
        float angle_rad = angle_deg * (float)(Math.PI / 180);
        return new Vector3(Mathf.Sin(angle_rad), Mathf.Cos(angle_rad), 0f) * speed * range;

    }

    void spawn_small_as(Vector3 velocity){
        GameObject new_as = Instantiate(small_as, transform.position, transform.rotation);
        new_as.GetComponent<Rigidbody2D>().velocity = velocity;

    }

    void break_up(){
        List<int> break_distribution = new List<int> {2, 2, 2, 2, 2, 2, 3, 3, 3, 4};
        int number_of_asteroids = break_distribution[rand.Next(break_distribution.Count)];
        for (int i = 1; i <= number_of_asteroids; i++){
            spawn_small_as(random_velocity());
        }

    }

    void OnCollisionEnter2D(Collision2D crash) {
        break_up();
        GameObject.Find("score_board").GetComponent<Score_script>().the_score += 30;
        Destroy(gameObject); 
    }

    void OnTriggerEnter2D(Collider2D other) {
        break_up();
        GameObject.Find("score_board").GetComponent<Score_script>().the_score += 30;
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
}
