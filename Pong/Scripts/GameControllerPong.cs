using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class GameControllerPong : MonoBehaviour
{
    [SerializeField] private Transform playerOne;
    [SerializeField] private Transform playerTwo;
    [SerializeField] private Transform ball;
    [SerializeField] public TextMeshProUGUI playerOneScoreText;
    [SerializeField] public TextMeshProUGUI playerTwoScoreText;

    public int playerOneScore = 0;
    public int playerTwoScore = 0;
    public static GameControllerPong instance;

    public static GameControllerPong Instance {
        get {
            if (instance == null) {
                instance = FindObjectOfType<GameControllerPong>();
            }
            return instance;
        }
    }

    void Start() {
        playerOneScore = 0;
        playerOneScoreText.SetText(playerOneScore.ToString());
        playerTwoScore = 0;
        playerTwoScoreText.SetText(playerTwoScore.ToString());
    }

    public void IncreasePlayerOneScore(int score) {
        playerOneScore += 1;
        playerOneScoreText.SetText(playerOneScore.ToString());
    }

    public void IncreasePlayerTwoScore(int score) {
        playerTwoScore += 1;
        playerTwoScoreText.SetText(playerTwoScore.ToString());
    }

    public void Restart() {
        playerOne.position = new Vector2(playerOne.position.x, 0);
        playerTwo.position = new Vector2(playerTwo.position.x, 0);
        ball.position = new Vector2(0, 0);
    }

}
