using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class ScoreManager : MonoBehaviour
{

    public TMP_Text player1Text;
    public TMP_Text player2Text;

    public int player1Score = 0;
    public int player2Score = 0;


    private void Start()
    {
        player1Text.text = player1Score.ToString();

        player2Text.text = player2Score.ToString();
    }
    public void AddPlayerKills(bool playerOne)
    {
        if(playerOne)
        {
            player1Score++;
            player1Text.text = player1Score.ToString();
        }
        else
        {
            player2Score++;
            player2Text.text = player2Score.ToString();
        }
    }
}
