//TODO: BUFF VILLAIN, EASIER POINT COLLECTION

using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Villain_Move : MonoBehaviour
{
    // Start is called before the first frame update

    private float exp = 1.1f; //some exponential speed to make it feel better

    private float max_accel = 4.5f; // bound how high exp can get
    public float forward_speed; //base speed 
    static public bool v_isMoving = false; //makes sure that the villain can only move up when its not already moving (avoid super fast villain bug)
    static public bool v_isSwitching = false;

    static public bool EXPLODED = false;

    [SerializeField]
    private GameObject explosion;

    static public int vtrack = 1; //collision purposes (villain has no volume, just needs to be in same track to hit the trolley)
    void Start()
    {
        // resetting static variables
        v_isMoving = false;
        v_isSwitching = false;
        EXPLODED = false;
        vtrack = 1;

        forward_speed = 0.03f; //manually set speed (testing says this works nice, subject to change)
    }
    // Update is called once per frames
    //Can't be delayed, need booleans like v_isMoving to properly implement delays
    //ex: without v_isMoving, StartCoroutine(moveBack()) could be called over and over and over and over (buggy)
    void Update()
    {
        // Horizontal movement
        if (!v_isMoving) {
            //StartCoroutine calls move
            StartCoroutine(move());
        }
        // Rail/vertical movement
        if (!v_isSwitching) {
            StartCoroutine(move_tracks());
        }
    }
    //for moving left and right 
    IEnumerator move() {
        //bounds: -4.79 < x < 4.79
        exp = 1.1f;
        v_isMoving = true; 
        while(Input.GetAxis("P2_Horizontal") > 0 && transform.position.x < 4.79) {
            transform.position += exp * forward_speed * transform.right; 
            exp += (exp < max_accel) ? 0.1f : 0.0f;
            yield return new WaitForSeconds(0.01f);
        }
        
        exp = 1.1f;
        while(Input.GetAxis("P2_Horizontal") < 0 && transform.position.x > -4.79) {
            transform.position -= exp * forward_speed * transform.right; 
            exp += (exp < max_accel) ? 0.1f : 0.0f;
            yield return new WaitForSeconds(0.01f);
        }

        while(transform.position.x > 4.79) {
            transform.position -= 0.0005f * transform.right; 
            if(Input.GetAxis("P2_Horizontal") < 0) {
                break;
            }
            yield return new WaitForSeconds(0.01f);
        }

        while(transform.position.x < -4.79) {
            transform.position += 0.0005f * transform.right; 
            if(Input.GetAxis("P2_Horizontal") > 0) {
                break;
            }
            yield return new WaitForSeconds(0.01f);
        }

        v_isMoving = false;
    }

    IEnumerator move_tracks()
        {
            v_isSwitching = true;
            float scale = 0.25f;

            //go "up" if press up arrow
            while(Input.GetAxis("P2_Vertical") > 0) {
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
            while(Input.GetAxis("P2_Vertical") < 0) {
                
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
            v_isSwitching =  false;
        }
    
    private void OnTriggerEnter(Collider target)
    {
        if(target.gameObject.tag.Equals("trolley") == true) {
            GameObject newExplosion = Instantiate(explosion, transform.position + transform.up * 3.7f, Quaternion.identity);
            MinigameController.Instance.AddScore(2,1);
            MinigameController.Instance.AddScore(1, 60 - (int) MinigameController.Instance.GetElapsedTime());
            EXPLODED = true;
            

            if(MinigameController.Instance.Score1Text)
            {
                MinigameController.Instance.Score1Text.SetText((MinigameController.Instance.GetScore(1)).ToString());
            }

            if(MinigameController.Instance.Score2Text)
            {
                MinigameController.Instance.Score2Text.SetText((MinigameController.Instance.GetScore(2)).ToString());
            }

            if(MinigameController.Instance.GetScore(1) > MinigameController.Instance.GetScore(2)) {
                Debug.Log(MinigameController.Instance.GetScore(1));
                Debug.Log(MinigameController.Instance.GetScore(2));

                MinigameController.Instance.FinishGame(LastMinigameFinish.P1WIN);
            }
            else if(MinigameController.Instance.GetScore(1) < MinigameController.Instance.GetScore(2)) {
                Debug.Log(MinigameController.Instance.GetScore(1));
                Debug.Log(MinigameController.Instance.GetScore(2));
                MinigameController.Instance.FinishGame(LastMinigameFinish.P2WIN);
            }
            else {
                Debug.Log(MinigameController.Instance.GetScore(1));
                Debug.Log(MinigameController.Instance.GetScore(2));
                 MinigameController.Instance.FinishGame(LastMinigameFinish.TIE);
            }

            Destroy(gameObject);
            
        }
    }
}
