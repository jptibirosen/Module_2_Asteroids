using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class small_as_script : MonoBehaviour
{

    void OnCollisionEnter2D(Collision2D crash) {
        GameObject.Find("score_board").GetComponent<Score_script>().the_score += 50;
        Destroy(gameObject);       
    }

    void OnTriggerEnter2D(Collider2D other) {
        GameObject.Find("score_board").GetComponent<Score_script>().the_score += 50;
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
