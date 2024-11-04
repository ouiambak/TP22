using UnityEngine;
using TMPro;
using System.Collections.Generic;

public class ScoreManager : MonoBehaviour
{
    private int _score = 0; 
    [SerializeField] private TextMeshProUGUI _scoreText; 
    [SerializeField] private bool _isFirstScene = false; 

    private const string _ScoreKey = "PlayerScore";
    private void Awake()
    {
        DontDestroyOnLoad(gameObject); 
    }

    private void Start()
    {
        if (!_isFirstScene)
        {
            _score = PlayerPrefs.GetInt(_ScoreKey, 0);
            Debug.Log("Score chargé : " + _score);
        }

        LoadScore();
        UpdateScoreText();
       

    }
    private void LoadScore()
    {
        _score = PlayerPrefs.GetInt("currentScore", _score);
    }
    public void AddScore(Collectible collectible)
    {
        _score += collectible.points;
        UpdateScoreText();
        PlayerPrefs.SetInt("currentScore", _score);
        PlayerPrefs.Save();
        Debug.Log("Score sauvegardé dans PlayerPrefs avec la clé " + _ScoreKey + ": " + PlayerPrefs.GetInt(_ScoreKey));
    }


    private void UpdateScoreText()
    {
        _scoreText.text = $"Score: {_score} points"; 
    }

    public void SavePlayerScore(string playerName)
    {
        SaveCurrentScore(playerName); 
    }

    /*private void SaveCurrentScore(string playerName)
    {
        
        PlayerPrefs.SetString("currentPlayer", playerName);
        PlayerPrefs.SetInt("currentScore",_score);
        PlayerPrefs.Save();

    }*/

    public void SaveCurrentScore(string playerName)
    {
        List<string> scoresList = new List<string>();

        for (int i = 0; i < 5; i++)
        {
            string existingName = PlayerPrefs.GetString("currentPlayer" + i, "");
            int existingScore = PlayerPrefs.GetInt("currentScore" + i, -1);

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
            PlayerPrefs.SetString("currentPlayer" + i, parts[0]);
            PlayerPrefs.SetInt("currentScore" + i, int.Parse(parts[1]));
        }

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
            string playerName = PlayerPrefs.GetString("currentPlayer" + i, "");
            int score = PlayerPrefs.GetInt("currentScore" + i, 0);

            if (!string.IsNullOrEmpty(playerName))
            {
                Debug.Log($"{playerName}: {score} points");
            }
        }
    }
}
   


