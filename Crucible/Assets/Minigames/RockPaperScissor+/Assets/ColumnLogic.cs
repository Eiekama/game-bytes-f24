using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ColumnLogic : MonoBehaviour
{
    // Start is called before the first frame update
    [SerializeField] private int player;
    [SerializeField] private int Column;
    private int selection = 0;
    private int elements = 12;
    private float moveSpeed = 0.817f;    
    private string a;
    private string b;    
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
         if (GamePlayer.Instance.GetElapsedTime() <= 29.9f && Input.GetButtonDown(a))
        { 
            selection = (selection+1);
            if(selection>elements){
                transform.Translate(Vector2.down *moveSpeed *elements);
                selection = 1;
            }
        }
        if (GamePlayer.Instance.GetElapsedTime() <= 29.9f && Input.GetButtonDown(b))
        {
            selection = (selection-1);
            if(selection<elements*-1){
                transform.Translate(Vector2.up *moveSpeed *elements);
                selection = -1;
            }
        }
    }
}
