using UnityEngine;
using TMPro;

public class ScoreManager : MonoBehaviour
{
    private int _score = 0; 
    [SerializeField] private TextMeshProUGUI _scoreText; 
    [SerializeField] private bool _isFirtsScene = true;
    
    private const string ScoreKey = "PlayerScore";
    private const string TopScoresKey = "TopScores";
    private const int MaxScores = 5; 

    private void Start()
    {
        if (_isFirtsScene)
        {
            _score = 0;
        }else{
            _score = PlayerPrefs.GetInt(ScoreKey);
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
        
        string currentScores = PlayerPrefs.GetString(TopScoresKey, "");
        string newEntry = $"{playerName}:{_score};";
        currentScores += newEntry;

        
        PlayerPrefs.SetString(TopScoresKey, currentScores);
        PlayerPrefs.Save();
    }

    public string GetTopScores()
    {
        
        string[] scores = PlayerPrefs.GetString(TopScoresKey, "").Split(';');
        System.Array.Sort(scores, (x, y) => int.Parse(y.Split(':')[1]).CompareTo(int.Parse(x.Split(':')[1]))); 

        string displayText = "Leaderboard:\n";
        for (int i = 0; i < Mathf.Min(MaxScores, scores.Length); i++)
        {
            if (string.IsNullOrEmpty(scores[i])) continue;
            displayText += $"{scores[i]}\n"; 
        }

        return displayText;
    }

    public void ResetScore()
    {
        _score = 0;
        PlayerPrefs.SetInt(ScoreKey, _score);
        PlayerPrefs.Save();
    }
}
