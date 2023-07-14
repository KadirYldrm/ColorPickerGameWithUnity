using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using System.Text;

public class LeaderboardManager : MonoBehaviour
{
    private List<int> scores; 
    public Text leaderboardText;
    public Text highscoreText;
    private Menu menu;

    private void Start()
    {
        menu = FindObjectOfType<Menu>(); 
        int highscore = PlayerPrefs.GetInt("Highscore");
        highscoreText.text = "Highscore: " + highscore.ToString();
        scores = new List<int>();
        LoadScores();
        UpdateLeaderboardText();
    }

    public void AddScore(){

        scores.Add(menu.highscore);
        scores.Sort();
        scores.Reverse();
        if (scores.Count > 10)
        {
            scores.RemoveAt(scores.Count - 1);
        }

        SaveScores();
        UpdateLeaderboardText();
    }



    public void ShowLeaderboard()
    {
        UpdateLeaderboardText();
    }

    private void UpdateLeaderboardText(){


        StringBuilder stringBuilder = new StringBuilder();
        stringBuilder.AppendLine("Leaderboard:");

        for (int i = 0; i < scores.Count && i < 10; i++)
        {
            stringBuilder.AppendLine($"Rank {i + 1}: {scores[i]}");
        }

        leaderboardText.text = stringBuilder.ToString();
    }

    private void SaveScores()
    {
        string scoresData = string.Join(",", scores);
        PlayerPrefs.SetString("Leaderboard", scoresData);
    }

    public void ClearLeaderboard(){
        scores.Clear();
        SaveScores();
        UpdateLeaderboardText();
    }


    private void LoadScores()
    {
        string scoresData = PlayerPrefs.GetString("Leaderboard");
        if (!string.IsNullOrEmpty(scoresData))
        {
            string[] scoresArray = scoresData.Split(',');
            scores = new List<int>();
            foreach (string score in scoresArray)
            {
                scores.Add(int.Parse(score));
            }
        }
        else
        {
            scores = new List<int>(); 
        }
    }
}
