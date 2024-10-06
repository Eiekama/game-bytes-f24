using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Trolley_Move : MonoBehaviour
{
    // Start is called before the first frame update

    public float moveIncrement; 
    public bool isMoving = false;
    void Start()
    {
       
    }
    // Update is called once per frames
    void Update()
    {

        if (!isMoving) {
            StartCoroutine(moveBack());
           // StartCoroutine(moveForward());
        }
    }

    
    IEnumerator moveBack()
        {
            isMoving = true;
            float scale = 0.25f;

            if(Input.GetKeyDown(KeyCode.W)) {
                // for (float i = 0.01f; i <= 0.25f; i += 0.01f) {
                //     transform.position += scale * transform.forward * (2.0f*i);
                //     yield return new WaitForSeconds(0.01f);
                // }
                for (float i = 0.01f; i <= 0.25f; i += 0.01f) {
                    transform.position += scale * transform.forward * (3.0f*i);
                    yield return new WaitForSeconds(0.01f);
                }
                for (float i = 0.01f; i <= 0.25f; i += 0.01f) {
                    transform.position += -1.0f * scale * transform.forward * (0.5f*i);
                    yield return new WaitForSeconds(0.01f);
                }
            }

            if(Input.GetKeyDown(KeyCode.S)) {
                // for (float i = 0.01f; i <= 0.25f; i += 0.01f) {
                //     transform.position += scale * transform.forward * (2.0f*i);
                //     yield return new WaitForSeconds(0.01f);
                // }
                for (float i = 0.01f; i <= 0.25f; i += 0.01f) {
                    transform.position -= scale * transform.forward * (3.0f*i);
                    yield return new WaitForSeconds(0.01f);
                }
                for (float i = 0.01f; i <= 0.25f; i += 0.01f) {
                    transform.position -= -1.0f * scale * transform.forward * (0.5f*i);
                    yield return new WaitForSeconds(0.01f);
                }
            }
            //move ths to new coroutine and call it outside the if 
            //yield return new WaitForSeconds(0.25f);
            isMoving =  false;
        }
    
    IEnumerator moveForward()
        {
            isMoving = true;
            float scale = 0.25f;

            if(Input.GetKeyDown(KeyCode.S)) {
                // for (float i = 0.01f; i <= 0.25f; i += 0.01f) {
                //     transform.position += scale * transform.forward * (2.0f*i);
                //     yield return new WaitForSeconds(0.01f);
                // }
                for (float i = 0.01f; i <= 0.25f; i += 0.01f) {
                    transform.position -= scale * transform.forward * (3.0f*i);
                    yield return new WaitForSeconds(0.01f);
                }
                for (float i = 0.01f; i <= 0.25f; i += 0.01f) {
                    transform.position -= -1.0f * scale * transform.forward * (0.5f*i);
                    yield return new WaitForSeconds(0.01f);
                }
            }
            //move ths to new coroutine and call it outside the if 
            //yield return new WaitForSeconds(0.25f);
            isMoving =  false;
        }
    
}
