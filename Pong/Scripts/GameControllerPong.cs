using UnityEngine;
using TMPro;
using System;

public class GameControllerPong : MonoBehaviour
{
    [SerializeField] private Transform playerOne;
    [SerializeField] private Transform playerTwo;
    [SerializeField] private Transform ball;
    [SerializeField] public TextMeshProUGUI playerOneScoreText;
    [SerializeField] public TextMeshProUGUI playerTwoScoreText;
    [SerializeField] public TextMeshProUGUI winnerMessage;
    [SerializeField] public TextMeshProUGUI scorePoints;
    [SerializeField] public SoundControllerPong soundController;
    [SerializeField] public StyleControllerPong styleController;
    [SerializeField] public GameObject gameScreen;
    [SerializeField] public GameObject pauseScreen;
    [SerializeField] public GameObject restartScreen;
    [SerializeField] public GameObject scoresCanvas;
    [SerializeField] public GameObject restartCanvas;
    [SerializeField] public GameObject pauseCanvas;
    [SerializeField] private int maxPoints;

    public int playerOneScore = 0;
    public int playerTwoScore = 0;
    public static GameControllerPong instance;
    public bool isPaused = false;

    public static GameControllerPong Instance {
        get {
            if (instance == null) {
                instance = FindObjectOfType<GameControllerPong>();
            }
            return instance;
        }
    }

    void Start() {
        GetGameObjects();
        SetStyles();
        SetPlayerScores();
        ActivateGameEntities();
        SetVictoryConditions();
    }

    void Update() {
        if (Input.GetKeyDown(KeyCode.P)) {
            if (!isPaused) {
                PauseGame();
            } else {
                ResumeGame();
            }
        }        
    }

    private void PauseGame() {
        isPaused = true;
        Time.timeScale = 0;
        pauseCanvas.SetActive(true);
    }

    private void ResumeGame() {
        isPaused = false;
        Time.timeScale = 1;
        pauseCanvas.SetActive(false);
    }

    private void GetGameObjects() {
        styleController = GetComponent<StyleControllerPong>();
        gameScreen = GameObject.Find("GameScreen");
        pauseScreen = GameObject.Find("PauseScreen");
        restartScreen = GameObject.Find("RestartScreen");
        scoresCanvas = GameObject.Find("ScoreCanvas");
        restartCanvas = GameObject.Find("RestartCanvas");
        pauseCanvas = GameObject.Find("PauseCanvas");
    }

    private void SetStyles() {
        styleController.SetColorStyle();
    }

    private void SetPlayerScores() {
        playerOneScore = 0;
        playerOneScoreText.SetText(playerOneScore.ToString());
        playerTwoScore = 0;
        playerTwoScoreText.SetText(playerTwoScore.ToString());
    }

    private void ActivateGameEntities() {
        gameScreen.SetActive(true);
        scoresCanvas.SetActive(true);
        restartCanvas.SetActive(false);
        pauseCanvas.SetActive(false);
    }

    private void SetVictoryConditions() {
        maxPoints = 5;
        if (PlayerPrefs.GetInt("maxPoints") != 0) {
            maxPoints = PlayerPrefs.GetInt("maxPoints");
        }
    }

    public void IncreasePlayerOneScore(int score) {
        playerOneScore += 1;
        playerOneScoreText.SetText(playerOneScore.ToString());
        if(playerOneScore < maxPoints) {
            soundController.PlayPointSound();
        }
        if (playerOneScore == maxPoints) {
            soundController.PlayVictorySound();
            winnerMessage.SetText("Player 1 Wins!");
            SetRestartScreen();
        }
    }

    public void IncreasePlayerTwoScore(int score) {
        playerTwoScore += 1;
        playerTwoScoreText.SetText(playerTwoScore.ToString());
        if (playerOneScore < maxPoints) {
            soundController.PlayPointSound();
        }
        if (playerTwoScore == maxPoints) {
            soundController.PlayVictorySound();
            winnerMessage.SetText("Player 2 Wins!");
            SetRestartScreen();
        }
    }

    private void SetRestartScreen() {
        scorePoints.SetText(playerOneScore + " - " + playerTwoScore);
        gameScreen.SetActive(false);
        scoresCanvas.SetActive(false);
        restartCanvas.SetActive(true);
    }

    public void Restart() {
        playerOne.position = new Vector2(playerOne.position.x, 0);
        playerTwo.position = new Vector2(playerTwo.position.x, 0);
        ball.position = new Vector2(0, 0);
    }

}
