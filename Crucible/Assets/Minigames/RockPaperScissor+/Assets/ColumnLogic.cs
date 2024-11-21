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
    private KeyCode a;
    private KeyCode b;    
    void Start()
    {
       if (player == 0 && Column == 0){
            a = KeyCode.Q;
            b = KeyCode.A;
        } else if (player == 0 && Column == 1){
            a = KeyCode.W;
            b = KeyCode.S;
        } else if (player == 0 && Column == 2){
            a = KeyCode.E;
            b = KeyCode.D;
        } else if (player == 1 && Column == 0){
            a = KeyCode.U;
            b = KeyCode.J;
        } else if (player == 1 && Column == 1){
            a = KeyCode.I;
            b = KeyCode.K;
        } else if (player == 1 && Column == 2){
            a = KeyCode.O;
            b = KeyCode.L;
        }
    }

    // Update is called once per frame
    void Update()
    {
         if (GamePlayer.Instance.GetElapsedTime() <= 29.9f && Input.GetKeyDown(a))
        { 
            selection = (selection+1);
            if(selection>elements){
                transform.Translate(Vector2.down *moveSpeed *elements);
                selection = 1;
            }
        }
        if (GamePlayer.Instance.GetElapsedTime() <= 29.9f && Input.GetKeyDown(b))
        {
            selection = (selection-1);
            if(selection<elements*-1){
                transform.Translate(Vector2.up *moveSpeed *elements);
                selection = -1;
            }
        }
    }
}
