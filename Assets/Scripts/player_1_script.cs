using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;




public class player_1_script : MonoBehaviour
{

    [SerializeField] float thrust = 40f;
    [SerializeField] float torque = 0.5f;
    [SerializeField] float turn_limit = 30f;
    [SerializeField] bool invincible = false;


    bool turning_right = false;
    bool turning_left = false;

    private void OnCollisionEnter2D(Collision2D crash) {
        if(crash.gameObject.tag == "asteroid" && !invincible){
            Debug.Log(
                $"you died.\nyour score: {GameObject.Find("score_board").GetComponent<Score_script>().the_score}");
            Destroy(gameObject);
            SceneManager.LoadScene("over");
        }
    }

    void thrust_effects(){
        if (Input.GetKeyDown(KeyCode.UpArrow)){
            GetComponent<ParticleSystem>().Play();
        }
        if (Input.GetKeyUp(KeyCode.UpArrow)){
            GetComponent<ParticleSystem>().Stop();
        }
    }

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.RightArrow)){
            turning_right = true;
        }
        if (Input.GetKeyUp(KeyCode.RightArrow)){
            turning_right = false;
        }
        if (Input.GetKeyDown(KeyCode.LeftArrow)){
            turning_left = true;
        }
        if (Input.GetKeyUp(KeyCode.LeftArrow)){
            turning_left = false;
        }

        thrust_effects();
        
    }

    float speed(Vector2 velocity){
        return Mathf.Sqrt(velocity.x * velocity.x + velocity.y * velocity.y);
    }

    void FixedUpdate() {

        Rigidbody2D rigid_2D = gameObject.GetComponent<Rigidbody2D>();
        
        if (Input.GetKey(KeyCode.UpArrow) && speed(rigid_2D.velocity) < 1.7 * thrust){  //1.7 is an arbitrary limit
            rigid_2D.AddForce(transform.up * thrust);
        }
        if (turning_right){
            rigid_2D.angularVelocity = -120f;
        }
        else if (turning_left){
            rigid_2D.angularVelocity = 120f;
        }
        else{
            rigid_2D.angularVelocity = 0f;
        }
        /*if (Input.GetKey(KeyCode.LeftArrow) && Mathf.Abs(rigid_2D.angularVelocity) < turn_limit){
            rigid_2D.AddTorque(torque);
            //Debug.Log("turn left");
        }*/
    }
}
