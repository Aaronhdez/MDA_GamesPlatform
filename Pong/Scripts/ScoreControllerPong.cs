using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class ScoreControllerPong : MonoBehaviour
{
    private int playerOneScore = 0;
    private int playerTwoScore = 0;
    public TextMeshProUGUI playerOneScoreText;
    public TextMeshProUGUI playerTwoScoreText;
    public Object sceneController;

    void Start() {
        playerOneScore = 0;
        playerOneScoreText.SetText(playerOneScore.ToString());
        playerTwoScore = 0;
        playerTwoScoreText.SetText(playerTwoScore.ToString());
    }

    public void IncreasePlayerOneScore(int number) {
        playerOneScore += 1;
        playerOneScoreText.SetText(playerOneScore.ToString());
    }

    public void IncreasePlayerTwoScore(int number) {
        playerTwoScore += 1;
        playerTwoScoreText.SetText(playerTwoScore.ToString());
    }
}
