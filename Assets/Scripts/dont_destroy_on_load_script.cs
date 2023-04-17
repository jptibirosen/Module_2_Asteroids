using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class dont_destroy_on_load_script : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        DontDestroyOnLoad(gameObject);
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
