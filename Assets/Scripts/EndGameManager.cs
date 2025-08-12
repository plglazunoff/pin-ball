using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class EndGameManager : MonoBehaviour
{
    public static EndGameManager Instance;
    public TMP_Text CurrentScoreText;
    public TMP_Text BestScoreText;

    private int _bestScorePoints = 0;
    private GameManager _gameManager;

    private List<int> _highScores;
    private const int _maxScores = 10;
    private const string _highScoreKey = "HighScores";

    private void Awake()
    {
        _gameManager = FindObjectOfType<GameManager>();
        
        if(Instance == null)
        {
            Instance = this;
            DontDestroyOnLoad(gameObject);
        }
        else
        {
            Destroy(gameObject);
        }
        LoadHighScores();
    }

    private void LoadHighScores()
    {
        _highScores = new List<int>();
        string scores = PlayerPrefs.GetString(_highScoreKey, "");
        if (!string.IsNullOrEmpty(scores))
        {
            string[] scoreArray = scores.Split(',');
            foreach (string score in scoreArray)
            {
                if(int.TryParse(score, out int value))
                {
                    _highScores.Add(value);
                }
            }
        }
    }

    private void SaveHighScores()
    {
        string scores = string.Join(",", _highScores);
        PlayerPrefs.SetString(_highScoreKey, scores);
        PlayerPrefs.Save();
    }

    public void AddScore(int newScore)
    {
        _highScores.Add(newScore);
        _highScores.Sort((a, b) => b.CompareTo(a));
        if (_highScores.Count < _maxScores)
        {
            _highScores.RemoveAt(_highScores.Count - 1);
        }
        SaveHighScores();
    }

    public List<int> GetHighScores()
    {
        return new List<int>(_highScores);
    }

    private void Start()
    {
        GameManager.OnGameEnded += LoadScore;
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
        AddScore(_bestScorePoints);
        PlayerPrefs.SetInt("Score", _bestScorePoints);
        PlayerPrefs.Save();
    }

    public void LoadScore()
    {
        GameManager.OnGameEnded -= LoadScore;
        _bestScorePoints = PlayerPrefs.GetInt("Score", 0);
    }

}
