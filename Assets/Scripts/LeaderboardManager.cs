using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class LeaderboardManager : MonoBehaviour
{
    public TMP_Text[] LeaderListText;
    public Button RemoveLeaderboardButton;

    private void Start()
    {
        UpdateLeaderboard();
        RemoveLeaderboardButton.onClick.AddListener(() => PlayerPrefs.DeleteAll());
    }

    private void UpdateLeaderboard()
    {
        List<int> highScores = EndGameManager.Instance.GetHighScores();
        for (int i = 0; i < LeaderListText.Length; i++)
        {
            if (i < highScores.Count)
            {
                LeaderListText[i].text = i + 1 + ". " + highScores[i].ToString();
                
            }
            else
            {
                LeaderListText[i].text = i + 1 + "-";
                
            }
        }
    }
}
