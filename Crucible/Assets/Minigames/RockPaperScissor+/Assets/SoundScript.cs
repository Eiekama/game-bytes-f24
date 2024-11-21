using System.Collections;
using System.Collections.Generic;
using UnityEngine;
public class SoundScript : MonoBehaviour
{
    private AudioSource Sor1;
    // Start is called before the first frame update
    void Start()
    {
        Sor1 = GetComponent<AudioSource>();
    }

    // Update is called once per frame
    void Update()
    {
        if (GamePlayer.Instance.GetElapsedTime() <= 29.9f){
        if (Input.GetKeyDown(KeyCode.S) || Input.GetKeyDown(KeyCode.A)
        ||Input.GetKeyDown(KeyCode.D) || Input.GetKeyDown(KeyCode.Q)
        ||Input.GetKeyDown(KeyCode.W) || Input.GetKeyDown(KeyCode.E))
        Sor1.Play();
        }
    }
}
