using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WallTime : MonoBehaviour
{
    // Start is called before the first frame update
    public Collider2D collide;
    public GameObject P1;
    public static float timer;
    public static float timer2;
    void Start()
    {
        timer2=Vector3.Distance(P1.transform.position,collide.ClosestPoint(P1.transform.position));
    }

    // Update is called once per frame
    void Update()
    {
        timer=Vector3.Distance(P1.transform.position,collide.ClosestPoint(P1.transform.position));
        timer=System.Math.Min(timer,timer2);
    }
    public float getTimer()
    {
        return(timer);
    }
}
