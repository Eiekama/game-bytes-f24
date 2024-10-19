using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class MainController : MonoBehaviour
{
    private int friendsOne = 1;
    private int gpaOne = 400; //between 0 and 400
    private int friendsTwo = 1;
    private int gpaTwo = 400; //between 0 and 400
    [SerializeField] private TextMeshProUGUI playerOneF;
    [SerializeField] private TextMeshProUGUI playerOneG;
    [SerializeField] private TextMeshProUGUI playerTwoF;
    [SerializeField] private TextMeshProUGUI playerTwoG;

    // Start is called before the first frame update
    void Start()
    {
        updateText();
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    private void updateText()
    {
        playerOneF.text = friendsOne.ToString();
        playerOneG.text = (gpaOne/100.0).ToString("0.00");
        playerTwoF.text = friendsTwo.ToString();
        playerTwoG.text = (gpaTwo / 100.0).ToString("0.00");
    }

    public void setFriends(int player, int amount)
    {
        if (player == 0)
        {
            friendsOne = amount;
        } else
        {
            friendsTwo = amount;
        }
        updateText();
    }

    public void setGPA(int player, int amount)
    {
        if (player == 0)
        {
            gpaOne = amount;
        }
        else
        {
            gpaTwo = amount;
        }
        updateText();
    }

    public int getFriends(int player)
    {
        if (player == 0)
        {
            return friendsOne;
        }
        else
        {
            return friendsTwo;
        }
    }

    public int getGPA(int player)
    {
        if (player == 0)
        {
            return gpaOne;
        }
        else
        {
            return gpaTwo;
        }
    }
}
