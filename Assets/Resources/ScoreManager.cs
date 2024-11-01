using UnityEngine;
using TMPro;
using System.Collections.Generic;

public class ScoreManager : MonoBehaviour
{
    private int _score = 0; 
    [SerializeField] private TextMeshProUGUI _scoreText; 
    [SerializeField] private bool _isFirstScene = true; 

    private const string _ScoreKey = "PlayerScore"; 
    

    private void Start()
    {
       
        if (!_isFirstScene)
        {
            _score = PlayerPrefs.GetInt(_ScoreKey, 0); 
        }
        UpdateScoreText(); 
    }

    public void AddScore(Collectible collectible)
    {
        _score += collectible.points; 
        UpdateScoreText(); 
        PlayerPrefs.SetInt(_ScoreKey, _score); 
        PlayerPrefs.Save();
    }

    private void UpdateScoreText()
    {
        _scoreText.text = $"Score: {_score} points"; 
    }

    public void SavePlayerScore(string playerName)
    {
        SaveScore(playerName); 
    }

    private void SaveScore(string playerName)
    {
        List<string> scoresList = new List<string>(); 

    
        for (int i = 0; i < 5; i++)
        {
            string existingName = PlayerPrefs.GetString(_ScoreKey + i, "");
            int existingScore = PlayerPrefs.GetInt("Score_" + i, -1); // -1 si pas de score

            if (!string.IsNullOrEmpty(existingName) && existingScore >= 0)
            {
                scoresList.Add($"{existingName}:{existingScore}"); 
            }
        }

       
        scoresList.Add($"{playerName}:{_score}");

        
        scoresList.Sort((x, y) => int.Parse(y.Split(':')[1]).CompareTo(int.Parse(x.Split(':')[1])));

        
        for (int i = 0; i < Mathf.Min(5, scoresList.Count); i++)
        {
            string[] parts = scoresList[i].Split(':');
            PlayerPrefs.SetString(_ScoreKey + i, parts[0]);
            PlayerPrefs.SetInt("Score_" + i, int.Parse(parts[1]));
        }

        PlayerPrefs.Save();
    }

    public void ResetScore()
    {
        _score = 0; 
        PlayerPrefs.SetInt(_ScoreKey, _score); 
        PlayerPrefs.Save();
    }

    public void EndGame(string playerName)
    {
        SavePlayerScore(playerName); 
        DisplayScores(); 
    }

    public void DisplayScores()
    {
        for (int i = 0; i < 5; i++)
        {
            string playerName = PlayerPrefs.GetString("PlayerName_" + i, "");
            int score = PlayerPrefs.GetInt("Score_" + i, 0);

            if (!string.IsNullOrEmpty(playerName))
            {
                Debug.Log($"{playerName}: {score} points");
            }
        }
    }
   

}
