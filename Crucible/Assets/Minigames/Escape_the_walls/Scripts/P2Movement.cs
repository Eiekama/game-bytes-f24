using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class P2Movement : MonoBehaviour
{
    // Start is called before the first frame update
    Vector2 move;
    void Start()
    {
        move=new Vector2(0.0f, 0.0f);
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
        transform.position = position;
    }
}
