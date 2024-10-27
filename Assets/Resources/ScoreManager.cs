using UnityEngine;
using TMPro;

public class ScoreManager : MonoBehaviour
{
    private int _score = 0; // Score total
    [SerializeField] private TextMeshProUGUI _scoreText; // Référence au composant TextMeshPro

    private const string ScoreKey = "PlayerScore";
    private const string TopScoresKey = "TopScores";
    private const int MaxScores = 5; // Nombre maximum de scores à conserver

    private void Start()
    {
        _score = PlayerPrefs.GetInt(ScoreKey, 0); // Charger le score précédent
        UpdateScoreText(); // Initialiser le texte dès le départ
    }

    public void AddCollectible(Collectible collectible)
    {
        _score += collectible.points; // Ajouter les points du collectible au score total
        UpdateScoreText(); // Mettre à jour le texte après chaque collecte
        PlayerPrefs.SetInt(ScoreKey, _score); // Sauvegarder le score dans PlayerPrefs
        PlayerPrefs.Save(); // Sauvegarder les modifications
    }

    private void UpdateScoreText()
    {
        _scoreText.text = $"Score: {_score} points"; // Afficher simplement le score total
    }

    public void SaveScore(string playerName)
    {
        // Ajouter le score et le nom du joueur dans PlayerPrefs
        string currentScores = PlayerPrefs.GetString(TopScoresKey, "");
        string newEntry = $"{playerName}:{_score};";
        currentScores += newEntry;

        // Sauvegarder les scores dans PlayerPrefs
        PlayerPrefs.SetString(TopScoresKey, currentScores);
        PlayerPrefs.Save();
    }

    public string GetTopScores()
    {
        // Récupérer les scores et les trier
        string[] scores = PlayerPrefs.GetString(TopScoresKey, "").Split(';');
        System.Array.Sort(scores, (x, y) => int.Parse(y.Split(':')[1]).CompareTo(int.Parse(x.Split(':')[1]))); // Tri décroissant

        string displayText = "Leaderboard:\n";
        for (int i = 0; i < Mathf.Min(MaxScores, scores.Length); i++)
        {
            if (string.IsNullOrEmpty(scores[i])) continue;
            displayText += $"{scores[i]}\n"; // Afficher le nom et le score
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
