using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MurdererMovement : MonoBehaviour
{
    public float moveIncrement;
    public float horizontalSpeed;
    // Start is called before the first frame update
    void Start()
    { 
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.UpArrow)) {
            transform.position += transform.forward * moveIncrement;
        }
        if (Input.GetKeyDown(KeyCode.DownArrow)) {
            transform.position -= transform.forward * moveIncrement;
        }
        if (Input.GetKey(KeyCode.LeftArrow)) {
            transform.position -= transform.right * horizontalSpeed * Time.deltaTime;
        }
        if (Input.GetKey(KeyCode.RightArrow)) {
            transform.position += transform.right * horizontalSpeed * Time.deltaTime;
        }
    }
}
