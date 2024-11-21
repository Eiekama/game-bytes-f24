using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SoundScript2 : MonoBehaviour
{
    private AudioSource Sor2;
    // Start is called before the first frame update
    void Start()
    {
        Sor2 = GetComponent<AudioSource>();        
    }

    // Update is called once per frame
    void Update()
    {
        if (GamePlayer.Instance.GetElapsedTime() <= 29.9f){
        if (Input.GetButtonDown("P2_Button1") || Input.GetButtonDown("P2_Button2")
        ||Input.GetButtonDown("P2_Button3") || Input.GetButtonDown("P2_Button4")
        ||Input.GetButtonDown("P2_Button5") || Input.GetButtonDown("P2_Button6"))
        Sor2.Play();
        }
    }
}
