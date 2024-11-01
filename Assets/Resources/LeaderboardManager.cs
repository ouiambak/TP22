using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class LeaderboardManager : MonoBehaviour
{
    [SerializeField] private TextMeshProUGUI _leaderboardText; 
    
    private const int _MaxScores = 5;
    private List<string> _leaderboard = new List<string>();

    private void Start()
    {
        if (_leaderboardText == null)
        {
            Debug.LogError("TextMeshProUGUI pour le classement n'est pas assigné dans l'inspecteur !");
            return;
        }

       

        DisplayLeaderboard();
    }

    private void DisplayLeaderboard()
    {

        GetTopScores();

   
        _leaderboardText.text = string.Join("\n", _leaderboard);
        Debug.Log("Classement mis à jour.");
    }
    public void GetTopScores()
    {
        for (int i = 0; i < _MaxScores; i++)
        {
            string playerName = PlayerPrefs.GetString("PlayerScore" + i, "Joueur Inconnu");
            int score = PlayerPrefs.GetInt("Score_" + i, 0);
            _leaderboard.Add($"{i + 1}. {playerName} - {score} points");
        }
    }
}
