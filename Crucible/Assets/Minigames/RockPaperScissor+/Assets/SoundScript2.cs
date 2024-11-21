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
        if (Input.GetKeyDown(KeyCode.U) || Input.GetKeyDown(KeyCode.I)
        ||Input.GetKeyDown(KeyCode.O) || Input.GetKeyDown(KeyCode.J)
        ||Input.GetKeyDown(KeyCode.K) || Input.GetKeyDown(KeyCode.L))
        Sor2.Play();
        }
    }
}
