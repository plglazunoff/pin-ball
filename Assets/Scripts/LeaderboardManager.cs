using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class LeaderboardManager : MonoBehaviour
{
    public TMP_Text[] LeaderListText;

    private void Start()
    {
        UpdateLeaderboard();
    }

    private void UpdateLeaderboard()
    {
        Debug.Log("HELLO");
        List<int> highScores = EndGameManager.Instance.GetHighScores();
        for (int i = 0; i < LeaderListText.Length; i++)
        {
            if (i < highScores.Count)
            {
                LeaderListText[i].text = highScores[i].ToString();
                
            }
            else
            {
                LeaderListText[i].text = "-";
                Debug.Log(highScores[i].ToString());
            }
        }
    }
}
