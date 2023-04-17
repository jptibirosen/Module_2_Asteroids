using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class weapons_script : MonoBehaviour
{
    [SerializeField] GameObject bullet;
    [SerializeField] GameObject rail_pellet;
    [SerializeField] GameObject mine;
    float cooldown = 0f;    //used in the reload cycle
    [SerializeField] public string Weapon = "cannon";

    System.Random rand = new System.Random(); 



    
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {   
        if (Input.GetKey(KeyCode.Space) && cooldown <=0){
            if (Weapon == "cannon"){
                //Debug.Log("cannon fired");
                float bullet_lifetime = 1f;
                float reload_time = 0.25f;

                cooldown = reload_time;
                GameObject new_bullet = Instantiate(bullet, transform.position, transform.rotation);
                Destroy(new_bullet, bullet_lifetime);
            }

            if (Weapon == "shotgun"){
                //Debug.Log("shotgun fired");
                float bullet_lifetime = 0.3f;
                float reload_time = 1f;

                cooldown = reload_time;
                for (int i = 0; i < 11; i++){
                    float spread = (float)rand.Next(-30,31);
                    Vector3 spread_vector = transform.rotation.eulerAngles + new Vector3(0, 0, spread);
                    GameObject new_bullet = Instantiate(bullet, transform.position, Quaternion.Euler(spread_vector));
                    Destroy(new_bullet, bullet_lifetime);
                }
            }

            if (Weapon == "railgun"){
                float bullet_lifetime = 1f;
                float reload_time = 0.75f;

                cooldown = reload_time;
                GameObject new_pellet = Instantiate(rail_pellet, transform.position, transform.rotation);
                Destroy(new_pellet, bullet_lifetime);
            }

            if (Weapon == "mine"){
                float bullet_lifetime = 3f;
                float reload_time = 1f;

                cooldown = reload_time;
                GameObject new_mine = Instantiate(mine, transform.position, transform.rotation);
                Destroy(new_mine, bullet_lifetime);

            }
            
        }
        cooldown -= Time.deltaTime;
    }
        

        
        
        
    
}
