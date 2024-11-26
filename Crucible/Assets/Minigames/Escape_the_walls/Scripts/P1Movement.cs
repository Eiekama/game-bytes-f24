using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;

public class P1Movement : MonoBehaviour
{
    // Start is called before the first frame update
    float P1Distance;
    Vector2 move;
    void Start()
    {
        QualitySettings.vSyncCount = 0;
        Application.targetFrameRate = 40;
        move=new Vector2(0.0f, 0.0f);
    }

    // Update is called once per frame
    void Update()
    {
        Vector2 position = transform.position;
        float speed=0.1f;
        float horizontal=0.0f;
        float vertical=0.0f;
        if(Input.GetKey("a")){
            horizontal=-1.0f;
        }
        if(Input.GetKey("d")){
            horizontal=1.0f;
        }
        if(Input.GetKey("w")){
            vertical=1.0f;
        }
        if(Input.GetKey("s")){
            vertical=-1.0f;
        }
        move.x=speed*horizontal*Time.deltaTime;
        move.y=speed*vertical*Time.deltaTime;
        position=(position+move.normalized*0.08f);//moves at .08 per frame
        transform.position = position;
    }
}
