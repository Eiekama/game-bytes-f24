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
        if (Input.GetButtonDown("P1_Button1") || Input.GetButtonDown("P1_Button2")
        ||Input.GetButtonDown("P1_Button3") || Input.GetButtonDown("P1_Button4")
        ||Input.GetButtonDown("P1_Button5") || Input.GetButtonDown("P1_Button6"))
        Sor1.Play();
        }
    }
}
