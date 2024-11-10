using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;


public class RPS_Start_Script : UnitySingleton<RPS_Start_Script>
{
    // Start is called before the first frame update
    public int[] selection1 = new int[3];
    public int[] selection2 = new int[3];
    public int result = 0;
    void Start()
    {

    }
    // Update is called once per frame
   void Update()
    {
        if (GamePlayer.Instance.GetElapsedTime() <= 29.9f){
        if (Input.GetKeyDown(KeyCode.Q))
        {
            selection1[0] = (selection1[0]+1) % 12;
        }
        if (Input.GetKeyDown(KeyCode.W))
        {
            selection1[1] = (selection1[1]+1) % 12;
        }
        if (Input.GetKeyDown(KeyCode.E))
        {
            selection1[2] = (selection1[2]+1) % 12;
        }
        if (Input.GetKeyDown(KeyCode.A))
        {
            selection1[0] = (selection1[0]-1) % 12;
            if(selection1[0] < 0)
                selection1[0]+=12;
        }
        if (Input.GetKeyDown(KeyCode.S))
        {
            selection1[1] = (selection1[1]-1) % 12;
            if(selection1[1] < 0)
                selection1[1]+=12;
        }
        if (Input.GetKeyDown(KeyCode.D))
        {    
            selection1[2] = (selection1[2]-1) % 12;
            if(selection1[2] < 0)
                selection1[2]+=12;
        }
        if (Input.GetKeyDown(KeyCode.U))
        {
            selection2[0] = (selection2[0]+1) % 12;
        }
        if (Input.GetKeyDown(KeyCode.I))
        {
            selection2[1] = (selection2[1]+1) % 12;
        }
        if (Input.GetKeyDown(KeyCode.O))
        {
            selection2[2] = (selection2[2]+1) % 12;
        }
        if (Input.GetKeyDown(KeyCode.J))
        {
            selection2[0] = (selection2[0]-1) % 12;
            if(selection2[0] < 0)
                selection2[0]+=12;
        }
        if (Input.GetKeyDown(KeyCode.K))
        {
            selection2[1] = (selection2[1]-1) % 12;
            if(selection2[1] < 0)
                selection2[1]+=12;
        }
        if (Input.GetKeyDown(KeyCode.L))
        {
            selection2[2] = (selection2[2]-1) % 12;
            if(selection2[2] < 0)
                selection2[2]+=12;
        }
        }
    }
    
    public void compare(int s1, int s2){
        switch(s1)
        {
            case 0: //Scissor
                if (s2 == 1 || s2 == 9 || s2 == 3 || s2 == 11) result = -1; //Scissor beats Paper
                if (s2 == 2 || s2 == 4 || s2 == 5 || s2 == 6) result = 1; //Scissor loses Rock
                break;
        
            case 1: // Paper
                if (s2 == 0 || s2 == 3 || s2 == 6) result = 1; //Paper loses Scissor
                if (s2 == 2 || s2 == 5 || s2 == 7 || s2 == 9) result = -1; //Paper beats Rock
                break;
        
            case 2: //Rock
                if (s2 == 0 || s2 == 4 || s2 == 10 || s2 == 6) result = -1; //Rock beats Scissor
                if (s2 == 1 || s2 == 3 || s2 == 5 || s2 == 7 || s2 == 11 || s2 == 9) result = 1; //Rock loses Paper
                break;

            case 3: //Forgery
                if (s2 == 1 || s2 == 2 || s2 == 8 || s2 == 11) result = -1;
                if (s2 == 0 || s2 == 7 || s2 == 10 || s2 == 4 || s2 == 9) result = 1;
                break;

            case 4: //Gecko
                if (s2 == 3 || s2 == 9 || s2 == 0 || s2 == 11) result = -1;
                if (s2 == 5 || s2 == 6 || s2 == 7 || s2 == 2) result = 1;
                break;
            
            case 5: //Hammer
                if (s2 == 2 || s2 == 4 || s2 == 0 || s2 == 6 || s2 == 10) result = -1;
                if (s2 == 8 || s2 == 1 || s2 == 3 || s2 == 11 || s2 == 9) result = 1;
                break;

            case 6: // Cauldron
                if (s2 == 4 || s2 == 1 || s2 == 3 || s2 == 9 || s2 == 0) result = -1;
                if (s2 == 5 || s2 == 8 || s2 == 2) result = 1;
                break;
            
            case 7: //Copyright
                if (s2 == 3 || s2 == 9 || s2 == 4 || s2 == 2) result = -1;
                if (s2 == 10 || s2 == 11 || s2 == 1) result = 1;
                break;

            case 8: //Osha
                if (s2 == 5 || s2 == 6) result = -1;
                if (s2 == 3 || s2 == 10 || s2 == 9) result = 1;
                break;

            case 9: //Uno Reverse
                if (s2 == 1 || s2 == 2 || s2 == 3 || s2 == 5 || s2 == 8 || s2 == 11 || s2 == 12) result = -1;
                if (s2 == 0 || s2 == 7 || s2 == 4 || s2 == 6 || s2 == 10) result = 1;
                break;

            case 10: //Lawyer
                if (s2 == 7 || s2 == 8 || s2 == 3 || s2 == 9) result = -1;
                if (s2 == 2 || s2 == 11 || s2 == 5) result = 1;
                break;

            case 11: //Money
                if (s2 == 7 || s2 == 10 || s2 == 5 || s2 == 2) result = -1;
                if (s2 == 0 || s2 == 3 || s2 == 4 || s2 == 9) result = 1;
                break;
        }
    }

    public IEnumerator play(){
        compare(selection1[2],selection2[0]);
        if (result == -1){
            GamePlayer.Instance.P1Score++;
        } else if (result == 1){
            GamePlayer.Instance.P2Score++;  
        } else {
        }  
        result = 0;
        compare(selection1[1],selection2[1]);
        if (result == -1){
            GamePlayer.Instance.P1Score++;
        } else if (result == 1){
            GamePlayer.Instance.P2Score++;  
        } else {
        }  
        result = 0;
        compare(selection1[0],selection2[2]);
        if (result == -1){
            GamePlayer.Instance.P1Score++;
        } else if (result == 1){
            GamePlayer.Instance.P2Score++;  
        } else {
        }  
        //GamePlayer.Instance.FinishGame();
        if(GamePlayer.Instance.P1Score == GamePlayer.Instance.P2Score)
        {
            GamePlayer.Instance.FinishGame(LastMinigameFinish.TIE);
        }
        else
        {
            GamePlayer.Instance.FinishGame(GamePlayer.Instance.P1Score > GamePlayer.Instance.P2Score ? LastMinigameFinish.P1WIN : LastMinigameFinish.P2WIN);
        }        
        yield return new WaitForSeconds(1);
    }
}
