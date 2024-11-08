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
            selection1[0] = (selection1[0]+1) % 3;
        }
        if (Input.GetKeyDown(KeyCode.W))
        {
            selection1[1] = (selection1[1]+1) % 3;
        }
        if (Input.GetKeyDown(KeyCode.E))
        {
            selection1[2] = (selection1[2]+1) % 3;
        }
        if (Input.GetKeyDown(KeyCode.A))
        {
            selection1[0] = (selection1[0]-1) % 3;
            if(selection1[0] < 0)
                selection1[0]+=3;
        }
        if (Input.GetKeyDown(KeyCode.S))
        {
            selection1[1] = (selection1[1]-1) % 3;
            if(selection1[1] < 0)
                selection1[1]+=3;
        }
        if (Input.GetKeyDown(KeyCode.D))
        {    
            selection1[2] = (selection1[2]-1) % 3;
            if(selection1[2] < 0)
                selection1[2]+=3;
        }
        if (Input.GetKeyDown(KeyCode.U))
        {
            selection2[0] = (selection2[0]+1) % 3;
        }
        if (Input.GetKeyDown(KeyCode.I))
        {
            selection2[1] = (selection2[1]+1) % 3;
        }
        if (Input.GetKeyDown(KeyCode.O))
        {
            selection2[2] = (selection2[2]+1) % 3;
        }
        if (Input.GetKeyDown(KeyCode.J))
        {
            selection2[0] = (selection2[0]-1) % 3;
            if(selection2[0] < 0)
                selection2[0]+=3;
        }
        if (Input.GetKeyDown(KeyCode.K))
        {
            selection2[1] = (selection2[1]-1) % 3;
            if(selection2[1] < 0)
                selection2[1]+=3;
        }
        if (Input.GetKeyDown(KeyCode.L))
        {
            selection2[2] = (selection2[2]-1) % 3;
            if(selection2[2] < 0)
                selection2[2]+=3;
        }
        }
    }
    
    public void compare(int s1, int s2){
        if (s1 == 0){ //Scissor
            if (s2 == 1) result = -1; //Scissor beats Paper
            if (s2 == 2) result = 1; //Scissor loses Rock
        }
        if (s1 == 1){ // Paper
            if (s2 == 0) result = 1; //Paper loses Scissor
            if (s2 == 2) result = -1; //Paper beats Rock
        }
        if (s1 == 2){ //Rock
            if (s2 == 0) result = -1; //Rock beats Scissor
            if (s2 == 1) result = 1; //Rock loses Paper
        }
    }

    public IEnumerator play(){
        compare(selection1[0],selection2[0]);
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
        compare(selection1[2],selection2[2]);
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
