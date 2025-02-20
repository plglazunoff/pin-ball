using System;
using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class GameManager : MonoBehaviour
{
    public  Action OnGameEnded;
    public GameObject GameOverPanel;

    public int GameScore = 0;
    public static int BallCount = 1;
    public TMP_Text LivesLeft;
    public TMP_Text GameScoreText;
    public Button RestartButton;
    public Button ExitButton;

    private Animator _gameOverPanelAnimator;
    private EndGameManager _endGameManager;

    private void Awake()
    {
        _endGameManager = FindObjectOfType<EndGameManager>();
        _gameOverPanelAnimator = GameOverPanel.GetComponent<Animator>();
        OnGameEnded += EndGameHandler;
        RestartButton.onClick.AddListener(RestartGame);
        ExitButton.onClick.AddListener(ExitGame);
    }
    

    private void Update()
    {
        LivesLeft.text = $"Ball Lives: {BallCount.ToString()}";
        GameScoreText.text = $"Game Score: {GameScore.ToString()}";
    }
    private void EndGameHandler()
    {
        OnGameEnded -= EndGameHandler;
        LivesLeft.gameObject.SetActive(false);
        GameScoreText.gameObject.SetActive(false);
        _gameOverPanelAnimator.SetTrigger("GameOverPanel");
    }

    private void RestartGame()
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);
        GameScore = 0;
        BallCount = 1;
    }

    private void ExitGame()
    {
        Application.Quit();

    }

}
