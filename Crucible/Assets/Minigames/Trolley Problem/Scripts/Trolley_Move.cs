using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Trolley_Move : MonoBehaviour
{
    // Start is called before the first frame update

    // public float moveIncrement = 2; 
    public bool isMoving = false; //makes sure trolley can only switch tracks when its not doing so already (avoid switching multiple tracks at once, messes stuff up)
    private float exp = 1.1f; //some exponential speed to make it feel better
    public float forward_speed; //base speed 
    public bool isSpeeding = false; //makes sure that the trolley can only speed up when its not already speeding (avoid super fast trolley bug)

    public int track = 1; //collision purposes (trolley has no volume, just needs to be in same track to hit a guy)
    void Start()
    {
        forward_speed = 0.01f; //manually set speed (testing says this works nice, subject to change)
    }
    // Update is called once per frames
    //Can't be delayed, need booleans like isMoving to properly implement delays
    //ex: without isMoving, StartCoroutine(moveBack()) could be called over and over and over and over (buggy)
    void Update()
    {
        //makes sure that it can only move if it isn't moving already
        if (!isMoving) {
            //StartCoroutine calls move
            StartCoroutine(move_tracks());
        }
        //putting this seperate allows it to speed and switch at the same time
        if (!isSpeeding) {
            StartCoroutine(speed());
        }
    }
    //for speeding up to the right
    IEnumerator speed() {
        //bounds: -4.79 < x < 4.79
        isSpeeding = true; 
        while(Input.GetKey(KeyCode.D) && transform.position.x < 4.79) {
            transform.position += exp * forward_speed * transform.right; 
            exp += 0.1f;
            yield return new WaitForSeconds(0.01f);
        }
        exp = 1.1f;
        isSpeeding = false;
        while(transform.position.x > -4.79) {
            transform.position -= 0.001f * transform.right; 
            if (Input.GetKey(KeyCode.D)) {
                break;
            }
            yield return new WaitForSeconds(0.01f);
        }
    }

    //switching tracks
    IEnumerator move_tracks()
        {
            isMoving = true;
            float scale = 0.25f;

            //go "up" if press W
            if(Input.GetKeyDown(KeyCode.W)) {
                //bounds on how much it can switch (only 4 tracks)
                //for loops let it increment its location (animation but real time)
                if (track == 4) {
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
                        transform.position += scale * transform.forward * (3.0f*i);
                        yield return new WaitForSeconds(0.01f);
                    }
                    track++;
                    for (float i = 0.01f; i <= 0.25f; i += 0.01f) {
                        transform.position += -1.0f * scale * transform.forward * (0.5f*i);
                        yield return new WaitForSeconds(0.01f);
                    }
                }
            }

            //go "down" if press S
            //same code basically
            if(Input.GetKeyDown(KeyCode.S)) {
                
                if (track == 1) {
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
                        transform.position -= scale * transform.forward * (3.0f*i);
                        yield return new WaitForSeconds(0.01f);
                    }
                    track--;
                    for (float i = 0.01f; i <= 0.25f; i += 0.01f) {
                        transform.position -= -1.0f * scale * transform.forward * (0.5f*i);
                        yield return new WaitForSeconds(0.01f);
                    }
                }
                
            }
            isMoving =  false;
        }
    
}
