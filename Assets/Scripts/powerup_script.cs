using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class powerup_script : MonoBehaviour
{
    System.Random rand = new System.Random();

    string random_weapon(){
        List<string> list_of_weapons = new List<string>{"shotgun", "railgun", "mine", "cannon"};
        string current_weapon = GameObject.Find("weapon_mount").GetComponent<weapons_script>().Weapon;
        list_of_weapons.Remove(current_weapon);
        string weapon_string = list_of_weapons[rand.Next(list_of_weapons.Count)];
        return weapon_string;
    }
    void OnCollisionEnter2D(Collision2D crash) {
        GameObject.Find("score_board").GetComponent<Score_script>().the_score += 100;
        GameObject.Find("weapon_mount").GetComponent<weapons_script>().Weapon = random_weapon();
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
