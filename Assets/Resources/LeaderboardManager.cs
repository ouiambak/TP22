using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class LeaderboardManager : MonoBehaviour
{
    [SerializeField] private TextMeshProUGUI leaderboardText;

    private void Start()
    {
       
        if (leaderboardText == null)
        {
            Debug.LogError("TextMeshProUGUI pour le classement n'est pas assigné dans l'inspecteur !");
            return;
        }

        
        DisplayLeaderboard();
    }

    private void DisplayLeaderboard()
    {
        
        List<string> leaderboard = new List<string>();
        for (int i = 0; i < 5; i++)
        {
            string playerName = PlayerPrefs.GetString("PlayerName_" + i, "Joueur Inconnu");
            int score = PlayerPrefs.GetInt("Score_" + i, 0);
            Debug.Log($"Player: {playerName}, Score: {score}");
            leaderboard.Add($"{i + 1}. {playerName} - {score} points");
        }

       
        leaderboardText.text = string.Join("\n", leaderboard);
        Debug.Log("Classement mis à jour.");
    }
}
