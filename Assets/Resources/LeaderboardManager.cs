using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class LeaderboardManager : MonoBehaviour
{
    [SerializeField] private TextMeshProUGUI leaderboardText;

    private void Start()
    {
        // Assurez-vous que l'objet de texte est assign�
        if (leaderboardText == null)
        {
            Debug.LogError("TextMeshProUGUI pour le classement n'est pas assign� dans l'inspecteur !");
            return;
        }

        // R�cup�rez et affichez le classement
        DisplayLeaderboard();
    }

    private void DisplayLeaderboard()
    {
        // Chargez les scores stock�s
        List<string> leaderboard = new List<string>();
        for (int i = 0; i < 5; i++)
        {
            string playerName = PlayerPrefs.GetString("PlayerName_" + i, "Joueur Inconnu");
            int score = PlayerPrefs.GetInt("Score_" + i, 0);
            leaderboard.Add($"{i + 1}. {playerName} - {score} points");
        }

        // Affichez le classement
        leaderboardText.text = string.Join("\n", leaderboard);
        Debug.Log("Classement mis � jour.");
    }
}
