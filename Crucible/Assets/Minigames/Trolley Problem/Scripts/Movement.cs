using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Movement : MonoBehaviour
{
    // Start is called before the first frame update

    public float moveIncrement; 
    void Start()
    {
       
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.W)) {
            transform.position += transform.forward * moveIncrement;
        }
         if (Input.GetKeyDown(KeyCode.S)) {
            transform.position -= transform.forward * moveIncrement;
        }
    }
}
