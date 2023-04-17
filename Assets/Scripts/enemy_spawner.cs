using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;



public class enemy_spawner : MonoBehaviour
{

    [SerializeField] int spawn_interval = 10;
    [SerializeField] GameObject player;
    [SerializeField] GameObject large_as;
    int previous_no_of_intervals = 0;
    System.Random rand = new System.Random();

    
    Vector3 random_spawn_position(){    //gives us coordinates in the quadrant opposite the player
        float player_x = player.transform.position.x;
        float player_y = player.transform.position.y;
        int x_factor = 1;
        int y_factor = 1;

        if (player_x > 0){
            x_factor = -1;
        }

        if (player_y > 0){
            y_factor = -1;
        }
        
        int rand_x = rand.Next(1, 48);
        int rand_y = rand.Next(1, 20);

        Vector3 position = new Vector3(rand_x * x_factor, rand_y * y_factor, 0f);
        return position;

    }
    

    void spawn_large_as(Vector3 position){
        Quaternion zero_rotation = Quaternion.Euler(0, 0, 0);
        GameObject new_as = Instantiate(large_as, position, zero_rotation);

    }

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        int no_of_intervals = (int)Time.time / spawn_interval;
        if (no_of_intervals > previous_no_of_intervals){
            //Debug.Log(no_of_intervals);
            for (int i = 0; i < no_of_intervals; i++)
            {
                spawn_large_as(random_spawn_position());
            }
            previous_no_of_intervals = no_of_intervals;
        }

    }
}
