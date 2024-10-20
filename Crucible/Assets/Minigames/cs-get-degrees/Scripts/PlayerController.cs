using System;
using System.Collections;
using System.Collections.Generic;
using UnityEditor;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    //[SerializeField] GameObject player;
    [SerializeField] float speed = 1;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        //print("I am running :)");
        float horizontal = Input.GetAxis("P1_Horizontal");
        //print(horizontal);
        if (horizontal > 0)
        {
            transform.position += transform.right * speed * Time.deltaTime;
        }
        else if (horizontal < 0)
        {
            //Friend friend = new Friend(gameObject);
            //friend.SpawnFriend();
            transform.position += -transform.right * speed * Time.deltaTime;
        }
    }
}
