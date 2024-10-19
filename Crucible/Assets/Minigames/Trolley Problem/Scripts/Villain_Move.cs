using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Villain_Move : MonoBehaviour
{
    // Start is called before the first frame update

    private float exp = 1.1f; //some exponential speed to make it feel better
    public float forward_speed; //base speed 
    public bool isMoving = false; //makes sure that the villain can only move up when its not already moving (avoid super fast villain bug)
    public bool isSwitching = false;

    static public int vtrack = 1; //collision purposes (villain has no volume, just needs to be in same track to hit the trolley)
    void Start()
    {
        forward_speed = 0.005f; //manually set speed (testing says this works nice, subject to change)
    }
    // Update is called once per frames
    //Can't be delayed, need booleans like isMoving to properly implement delays
    //ex: without isMoving, StartCoroutine(moveBack()) could be called over and over and over and over (buggy)
    void Update()
    {
        //makes sure that it can only move if it isn't moving already (avoid super fast villain bug)
        //can't move left/right and switch tracks at the same time
        if (!isMoving && !isSwitching) {
            //StartCoroutine calls move
            StartCoroutine(move());
        }
        if (!isMoving && !isSwitching) {
            StartCoroutine(move_tracks());
        }
    }
    //for moving left and right 
    IEnumerator move() {
        //bounds: -4.79 < x < 4.79
        exp = 1.1f;
        isMoving = true; 
        while(Input.GetKey(KeyCode.RightArrow) && transform.position.x < 4.79) {
            transform.position += exp * forward_speed * transform.right; 
            exp += 0.1f;
            yield return new WaitForSeconds(0.01f);
        }
        
        exp = 1.1f;
        while(Input.GetKey(KeyCode.LeftArrow) && transform.position.x > -4.79) {
            transform.position -= exp * forward_speed * transform.right; 
            exp += 0.1f;
            yield return new WaitForSeconds(0.01f);
        }

        while(transform.position.x > 4.79) {
            transform.position -= 0.0005f * transform.right; 
            if(Input.GetKey(KeyCode.LeftArrow)) {
                break;
            }
            yield return new WaitForSeconds(0.01f);
        }

        while(transform.position.x < -4.79) {
            transform.position += 0.0005f * transform.right; 
            if(Input.GetKey(KeyCode.RightArrow)) {
                break;
            }
            yield return new WaitForSeconds(0.01f);
        }

        isMoving = false;
    }

    IEnumerator move_tracks()
        {
            isSwitching = true;
            float scale = 0.25f;

            //go "up" if press up arrow
            while(Input.GetKey(KeyCode.UpArrow)) {
                //bounds on how much it can switch (only 4 tracks)
                //for loops let it increment its location (animation but real time)
                if (vtrack == 4) {
                    //wiggles basically, can add a sound effect later
                    for (float i = 0.01f; i <= 0.25f; i += 0.01f) {
                        transform.position += scale * transform.forward * (0.5f*i);
                        yield return new WaitForSeconds(0.01f);
                    }
                    for (float i = 0.01f; i <= 0.25f; i += 0.01f) {
                        transform.position += -1.5f * scale * transform.forward * (0.5f*i);
                        yield return new WaitForSeconds(0.01f);
                    }
                    for (float i = 0.01f; i <= 0.25f; i += 0.01f) {
                        transform.position += 0.5f * scale * transform.forward * (0.5f*i);
                        yield return new WaitForSeconds(0.01f);
                    }
                }
                else {
                    for (float i = 0.01f; i <= 0.25f; i += 0.01f) {
                        transform.position += scale * transform.forward * (2.5f*i);
                        yield return new WaitForSeconds(0.01f);
                    }
                    vtrack++;
                }
            }

            //go "down" if press down arrow
            while(Input.GetKey(KeyCode.DownArrow)) {
                
                if (vtrack == 1) {
                    for (float i = 0.01f; i <= 0.25f; i += 0.01f) {
                        transform.position -= scale * transform.forward * (0.5f*i);
                        yield return new WaitForSeconds(0.01f);
                    }
                    for (float i = 0.01f; i <= 0.25f; i += 0.01f) {
                        transform.position -= -1.5f * scale * transform.forward * (0.5f*i);
                        yield return new WaitForSeconds(0.01f);
                    }
                    for (float i = 0.01f; i <= 0.25f; i += 0.01f) {
                        transform.position -= 0.5f * scale * transform.forward * (0.5f*i);
                        yield return new WaitForSeconds(0.01f);
                    }
                }
                else {
                    for (float i = 0.01f; i <= 0.25f; i += 0.01f) {
                        transform.position -= scale * transform.forward * (2.5f*i);
                        yield return new WaitForSeconds(0.01f);
                    }
                    vtrack--;
                }
                
            }
            isSwitching =  false;
        }
    
}
