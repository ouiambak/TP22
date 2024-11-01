using UnityEngine;
using TMPro;
using System.Collections.Generic;

public class ScoreManager : MonoBehaviour
{
    private int _score = 0;
    [SerializeField] private TextMeshProUGUI _scoreText;
    [SerializeField] private bool _isFirstScene = true;

    private const string ScoreKey = "PlayerScore";
    private const int MaxScores = 5;

    private void Start()
    {
        if (_isFirstScene)
        {
            _score = 0;
        }
        else
        {
            _score = PlayerPrefs.GetInt(ScoreKey, 0); 
        }
        UpdateScoreText();
    }

    public void AddScore(Collectible collectible)
    {
        _score += collectible.points;
        UpdateScoreText();
        PlayerPrefs.SetInt(ScoreKey, _score); 
        PlayerPrefs.Save();
    }

    private void UpdateScoreText()
    {
        _scoreText.text = $"Score: {_score} points";
    }

    public void SaveScore(string playerName)
    {
        
        List<string> scoresList = new List<string>();

        
        for (int i = 0; i < MaxScores; i++)
        {
            string existingName = PlayerPrefs.GetString("PlayerName_" + i, "");
            int existingScore = PlayerPrefs.GetInt("Score_" + i, -1); // -1 si pas de score

            if (!string.IsNullOrEmpty(existingName) && existingScore >= 0)
            {
                scoresList.Add($"{existingName}:{existingScore}");
            }
        }

        
        scoresList.Add($"{playerName}:{_score}");

        
        scoresList.Sort((x, y) => int.Parse(y.Split(':')[1]).CompareTo(int.Parse(x.Split(':')[1])));

        
        for (int i = 0; i < Mathf.Min(MaxScores, scoresList.Count); i++)
        {
            string[] parts = scoresList[i].Split(':');
            PlayerPrefs.SetString("PlayerName_" + i, parts[0]);
            PlayerPrefs.SetInt("Score_" + i, int.Parse(parts[1]));
        }

        PlayerPrefs.Save();
    }

    public void ResetScore()
    {
        _score = 0;
        PlayerPrefs.SetInt(ScoreKey, _score);
        PlayerPrefs.Save();
    }
}
