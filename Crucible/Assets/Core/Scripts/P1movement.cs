using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    //Start is called before the first frame update
    void Start()
    {
        
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
        Debug.Log(horizontal);
        if(Input.GetKey("w")){
            vertical=1.0f;
        }
        if(Input.GetKey("s")){
            vertical=-1.0f;
        }
        
        position.x=position.x+speed*horizontal;
        position.y=position.y+speed*vertical;
        transform.position = position;
        Debug.Log(position.x);
    }
}
