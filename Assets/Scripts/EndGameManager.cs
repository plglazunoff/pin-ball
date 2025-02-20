using System;
using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class EndGameManager : MonoBehaviour
{
    //public GameObject EndGamePanel;
    //public Button RestartButton;
    //public Button ExitButton;
    public TMP_Text CurrentScoreText;
    public TMP_Text BestScoreText;

    private int _bestScorePoints = 0;
    private GameManager _gameManager;

    private void Awake()
    {
        _gameManager = FindObjectOfType<GameManager>();
    }

    private void Start()
    {
        _gameManager.OnGameEnded += LoadScore;
        LoadScore();
    }

    private void Update()
    {
        if (_gameManager.GameScore > _bestScorePoints)
        {
            _bestScorePoints = _gameManager.GameScore;
            SaveScore();
        }

        CurrentScoreText.text = $"Current Score: {_gameManager.GameScore}";

        BestScoreText.text = $"Best Score: {_bestScorePoints}";
    }

    private void SaveScore()
    {
        PlayerPrefs.SetInt("Score", _bestScorePoints);
        PlayerPrefs.Save();
    }

    public void LoadScore()
    {
        _gameManager.OnGameEnded -= LoadScore;
        _bestScorePoints = PlayerPrefs.GetInt("Score", 0);
    }

}
