﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
public class RockPaperScissorsNukeController : UnitySingleton<RockPaperScissorsNukeController>
{
   private enum choice
    {
        ROCK,
        PAPER,
        SCISSORS,
        NUKE,
        ANTINUKE,
        NONE
    };

    private enum battleOutcome
    {
        P1WIN,
        P2WIN,
        TIE,
        INVALID
    };

    private enum RPSNGameState
    {
        CHOOSE_WEAPON,
        ANIMATIONS_WAIT,
        CHOOSE_STAGE
    };

    [System.Serializable]
    public struct Controls
    {
        public KeyCode P1Confirm;
        public KeyCode P1Rock;
        public KeyCode P1Paper;
        public KeyCode P1Scissors;
        public KeyCode P1Nuke;
        public KeyCode P1AntiNuke;
        public KeyCode P2Confirm;
        public KeyCode P2Rock;
        public KeyCode P2Paper;
        public KeyCode P2Scissors;
        public KeyCode P2Nuke;
        public KeyCode P2AntiNuke;
    };

    [Header("Gameplay")]
    private GameState gameState;
    [SerializeField] private RPSNGameState state;
    [SerializeField] private float RPSNChoiceWaitTime;
    [SerializeField] private float winnerChoiceDisplayTime;
    [SerializeField] private float chooseMinigameWaitTime;

    [SerializeField] private choice p1Choice;
    [SerializeField] private bool confirmedP1;
    [SerializeField] private choice p2Choice;
    [SerializeField] private bool confirmedP2;

    [SerializeField] private Controls controls;

    [SerializeField] private int numberOfMinigamesToChooseFrom;

    [Header("Sounds")]
    [SerializeField] private AudioSource effectsSource;
    [SerializeField] private AudioClip choiceSelected;

    [Header("Graphics")]
    [SerializeField] GameObject battleGraphics;
    [SerializeField] GameObject chooseMinigameGraphics;
    [SerializeField] TextMeshProUGUI p1ChoiceGUI;
    [SerializeField] TextMeshProUGUI p2ChoiceGUI;
    [SerializeField] TextMeshProUGUI winText;
    [SerializeField] TextMeshProUGUI RPSNcountdownTimer;
    [SerializeField] TextMeshProUGUI chooseMinigameTimer;

    
    void InitRockPaperScissorsNuke()
    {
        p1Choice = choice.NONE;
        p2Choice = choice.NONE;

        // init the graphics
        winText.enabled = false;
        p1ChoiceGUI.enabled = false;
        p2ChoiceGUI.enabled = false;

        state = RPSNGameState.ANIMATIONS_WAIT; 
    }


    private void Start()
    {
        gameState = GameState.Instance;
        InitRockPaperScissorsNuke();
        StartCoroutine(WaitForChoices());

    }

    // returns true if both players have selected a choice,
    // returns false otherise
    bool BothPlayersReady()
    {
        if (confirmedP1 && confirmedP2)
        {
            return true;
        }
        return false;
    }

    void DisplayBattleOutcome(battleOutcome outcome)
    {
        Debug.Log("Displaying the battle outcome");
        p1ChoiceGUI.SetText(p1Choice.ToString());
        p2ChoiceGUI.SetText(p2Choice.ToString());
        p1ChoiceGUI.enabled = true;
        p2ChoiceGUI.enabled = true;
        winText.enabled = true;
        switch (outcome)
        {
            case battleOutcome.INVALID:
                Debug.Log("Oh no! You've created an invalid battle outcome!");
                winText.SetText("##INVALID BATTLE OUTCOME##");
                break;

            case battleOutcome.P1WIN:
                winText.SetText("Player 1 Wins!");
                break;

            case battleOutcome.P2WIN:
                winText.SetText("Player 2 Wins!");
                break;

            case battleOutcome.TIE:
                winText.SetText("It's a tie!");
                break;
        }
        
    }

    // close the battle graphics and open the "choose minigame" graphics
    void OpenChooseMinigameGraphics()
    {
        battleGraphics.SetActive(false);
        chooseMinigameGraphics.SetActive(true);
    }
    // wait for the players to choose their move, display results from battle
    IEnumerator WaitForChoices()
    {
        state = RPSNGameState.CHOOSE_WEAPON;
        // wait for players to choose their move
        float choiceCounter = RPSNChoiceWaitTime;
        while (!BothPlayersReady() && choiceCounter > 1)
        {
            choiceCounter -= 0.01f;
            // update the counter
            RPSNcountdownTimer.SetText(Mathf.FloorToInt(choiceCounter).ToString());
            ChoiceListen();
            yield return new WaitForSeconds(0.01f);
        }
        battleOutcome result = Battle();

        // display the results of their choices
        DisplayBattleOutcome(result);
        float displayOutcomeCounter = winnerChoiceDisplayTime;
        while (displayOutcomeCounter > 1)
        {
            displayOutcomeCounter -= 0.1f;
            yield return new WaitForSeconds(0.1f);
        }

        // have the player who won the battle select the next stage
        StartCoroutine(ChooseMinigame());
    }


    // update variables with player's choice (rock, paper, scissors, nuke, antinuke)
    void ChoiceListen()
    {
        // player one controls

        if (Input.GetKey(controls.P1Confirm))
        {
            confirmedP1 = true;
        }
        else if (Input.GetKey(controls.P1Rock))
        {
            p1Choice = choice.ROCK;
        }
        else if (Input.GetKey(controls.P1Paper))
        {
            p1Choice = choice.PAPER;
        }
        else if (Input.GetKey(controls.P1Scissors)) 
        {
            p1Choice = choice.SCISSORS;
        }
        else if (Input.GetKey(controls.P1Nuke))
        {
            p1Choice = choice.NUKE;
        }
        else if (Input.GetKey(controls.P1AntiNuke))
        {
            p1Choice = choice.ANTINUKE;
        }

        //player two controls

        if (Input.GetKey(controls.P2Confirm))
        {
            confirmedP2 = true;
        }
        else if (Input.GetKey(controls.P2Rock))
        {
            p2Choice = choice.ROCK;
        }
        else if (Input.GetKey(controls.P2Paper))
        {
            p2Choice = choice.PAPER;
        }
        else if (Input.GetKey(controls.P2Scissors)) 
        {
            p2Choice = choice.SCISSORS;
        }
        else if (Input.GetKey(controls.P2Nuke))
        {
            p2Choice = choice.NUKE;
        }
        else if (Input.GetKey(controls.P2AntiNuke))
        {
            p2Choice = choice.ANTINUKE;
        }
    }



    // Let the player who won choose the minigame
    IEnumerator ChooseMinigame()
    {
        // state = RPSNGameState.CHOOSE_STAGE;
        SceneTransitionController.Instance.TransitionToScene("SelectMinigame");
        yield return null;
        // OpenChooseMinigameGraphics();
        // float choiceCounter = chooseMinigameWaitTime;
        // List<MinigameInfo> MinigamesToChooseFrom = RandomMinigamesSubset();
        // MinigameInfo selected = null;
        // while (selected == null && choiceCounter > 1)
        // {
        //     choiceCounter -= 0.01f;
        //     chooseMinigameTimer.SetText(Mathf.FloorToInt(choiceCounter).ToString());
        //     yield return new WaitForSeconds(0.01f);
        // }
        // // if the player has not selected a minigame by the time runs out, select a random minigame
        // if (selected == null)
        // {
        //     selected = MinigamesToChooseFrom[Mathf.FloorToInt(Random.Range(0, MinigamesToChooseFrom.Count))];
        // }
        // gameState.CurrentMinigame = selected;
        // SceneTransitionController.Instance.TransitionToScene("MinigameLauncher");
    }

    // randomly chooses rock, paper or scissors
    choice RandomChoice()
    {
        return (choice)Random.Range(0, 3); 
    }


    // returns the result rock paper scissors nuke battle
    battleOutcome Battle()
    {
        // if either of the players do not have a choice, select a random choice
        if (p1Choice == choice.NONE)
        {
            p1Choice = RandomChoice();
        }
        if (p2Choice == choice.NONE)
        {
            p2Choice = RandomChoice();
        }

        // p1 nuke
        if (p1Choice == choice.NUKE)
        {
            if (p2Choice == choice.ANTINUKE)
            {
                return battleOutcome.P2WIN;
            }
            else if (p2Choice == choice.NUKE)
            {
                return battleOutcome.TIE;
            }
            else
            {
                return battleOutcome.P1WIN;
            }
        }

        // p1 anti nuke
        if (p1Choice == choice.ANTINUKE)
        {
            if (p2Choice == choice.NUKE)
            {
                return battleOutcome.P1WIN;
            }
            else if (p2Choice == choice.ANTINUKE)
            {
                return battleOutcome.TIE;
            }
            else
            {
                return battleOutcome.P2WIN;
            }
        }

        // p1 rock
        if (p1Choice == choice.ROCK)
        {
            // rock beats scissors and antinuke
            if (p2Choice == choice.SCISSORS || p2Choice == choice.ANTINUKE)
            {
                return battleOutcome.P1WIN;
            // rock ties rock
            } else if (p2Choice == choice.ROCK)
            {
                return battleOutcome.TIE;
            }
            // rock loses to everything else
            else
            {
                return battleOutcome.P2WIN;
            }
        }

        // p1 scissors
        if (p1Choice == choice.SCISSORS)
        {
            // scissors beats paper and antinuke
            if (p2Choice == choice.PAPER || p2Choice == choice.ANTINUKE)
            {
                return battleOutcome.P1WIN;
            }
            // scissors ties scissors
            else if (p2Choice == choice.SCISSORS)
            {
                return battleOutcome.TIE;
            }
            // scissors loses to everything else
            else
            {
                return battleOutcome.P2WIN;
            }
        }

        // p1 paper
        if (p1Choice == choice.PAPER)
        {
            // paper beats rock and antinuke
            if (p2Choice == choice.ROCK || p2Choice == choice.ANTINUKE)
            {
                return battleOutcome.P1WIN;
            }
            // paper ties paper
            else if (p2Choice == choice.PAPER)
            {
                return battleOutcome.TIE;
            }
            // paper loses to everything else
            else
            {
                return battleOutcome.P2WIN;
            }
        }
        // THIS CASE SHOULD NEVER HAPPEN. FOR DEBUGGING
        return battleOutcome.INVALID;
    }

    // generates a random subset of minigames without repeats (if possible)
    List<MinigameInfo> RandomMinigamesSubset()
    {
        List<MinigameInfo> possibleChoiceCopy = new List<MinigameInfo>(gameState.SelectedMinigames);
        List<MinigameInfo> result = new List<MinigameInfo>();
        while (result.Count < numberOfMinigamesToChooseFrom)
        {
            // generate a new random index
            int randomInt1 = Mathf.RoundToInt(Random.Range(0, possibleChoiceCopy.Count));
            // add the random minigame to the result list
            result.Add(possibleChoiceCopy[randomInt1]);
            // remove the minigame that we added to result from possibleChoiceCopy (this ensures we dont have repeats)
            possibleChoiceCopy.RemoveAt(randomInt1);
            
            // if we run out of possible minigames to add, then allow repeats
            if (possibleChoiceCopy.Count == 0)
            {
                while (result.Count < numberOfMinigamesToChooseFrom)
                {
                    int randomInt2 = Mathf.RoundToInt(Random.Range(0, gameState.SelectedMinigames.Length));
                    // add the random minigame to the result list
                    result.Add(gameState.SelectedMinigames[randomInt2]);
                }
            }
        }
        return result;
    }
}
