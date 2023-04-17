using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using TMPro;


public class display_score_script : MonoBehaviour
{   
    [SerializeField] TextMeshProUGUI scoreboard;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if (SceneManager.GetActiveScene().name == "game"){
            int the_score = GameObject.Find("score_board").GetComponent<Score_script>().the_score;
            string the_text = $"Score: {the_score}";
            scoreboard.text = the_text;
        }
    }
}
