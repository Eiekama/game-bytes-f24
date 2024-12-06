using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class P2Movement : MonoBehaviour
{
    // Start is called before the first frame update
    Vector2 move;
    public Collider2D collide;
    Animator animator;
    public GameObject controller;
    void Start()
    {
        move=new Vector2(0.0f, 0.0f);
        animator=GetComponent<Animator>();
    }

    // Update is called once per frame
    void Update()
    {
        Vector2 position = transform.position;
        float speed=0.1f;
        float horizontal=0.0f;
        float vertical=0.0f;
        if(Input.GetKey("left")){
            horizontal=-1.0f;
        }
        if(Input.GetKey("right")){
            horizontal=1.0f;
        }
        if(Input.GetKey("up")){
            vertical=1.0f;
        }
        if(Input.GetKey("down")){
            vertical=-1.0f;
        }
        move.x=speed*horizontal*Time.deltaTime;
        move.y=speed*vertical*Time.deltaTime;
        position=position+move.normalized*0.04f;
        animator.SetFloat("IsRun",(float) 10000*move.magnitude);        
        transform.position = position;
        if(controller.GetComponent<MinigameController>().GetElapsedTime()>59.7){
            MinigameController.Instance.FinishGame(LastMinigameFinish.P1WIN);
        }
    }
    public void OnTriggerEnter2D(Collider2D collide){
        controller.GetComponent<MinigameController>().SetScore(2, 1);
        MinigameController.Instance.FinishGame(LastMinigameFinish.P2WIN);
        
    }
}
