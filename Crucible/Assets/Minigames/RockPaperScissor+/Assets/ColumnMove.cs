using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ColumnMove: MonoBehaviour
{
    [SerializeField] private int player;
    [SerializeField] private int Column;
    private float moveSpeed = 0.817f;
    private string a;
    private string b;
    // Start is called before the first frame update
    void Start()
    {
        if (player == 0 && Column == 0){
            a = "P1_Button1";
            b = "P1_Button4";
        } else if (player == 0 && Column == 1){
            a = "P1_Button2";
            b = "P1_Button5";
        } else if (player == 0 && Column == 2){
            a = "P1_Button3";
            b = "P1_Button6";
        } else if (player == 1 && Column == 0){
            a = "P2_Button1";
            b = "P2_Button4";
        } else if (player == 1 && Column == 1){
            a = "P2_Button2";
            b = "P2_Button5";
        } else if (player == 1 && Column == 2){
            a = "P2_Button3";
            b = "P2_Button6";
        }
    }

    // Update is called once per frame
    void Update()
    {
        if(Input.GetButtonDown(a) && GamePlayer.Instance.GetElapsedTime() <= 29.9f)
            transform.Translate(Vector2.up *moveSpeed);
        if(Input.GetButtonDown(b) && GamePlayer.Instance.GetElapsedTime() <= 29.9f)
            transform.Translate(Vector2.down *moveSpeed);
    }
}
