// ScoreManager.cs
/*using UnityEngine;
using System.Collections.Generic;
using System.Linq;
using TMPro; // Importation de TextMeshPro

using UnityEngine;
using TMPro; // N�cessaire pour TextMeshPro

public class ScoreManager : MonoBehaviour
{
    private int _score = 0; // Un seul score pour tous les collectibles
    [SerializeField] private TextMeshProUGUI _scoreText; // R�f�rence au composant TextMeshPro

    private void Start()
    {
        UpdateScoreText(); // Initialiser le texte d�s le d�part
    }

    public void AddCollectible(Collectible collectible)
    {
        _score += collectible.points; // Ajouter les points du collectible au score total
        UpdateScoreText(); // Mettre � jour le texte apr�s chaque collecte
    }

    private void UpdateScoreText()
    {
        _scoreText.text = $"Score: {_score} points"; // Afficher simplement le score total
    }
}*/
using UnityEngine;
using TMPro; // N�cessaire pour TextMeshPro

public class ScoreManager : MonoBehaviour
{
    private int _score = 0; // Score total
    [SerializeField] private TextMeshProUGUI _scoreText; // R�f�rence au composant TextMeshPro

    private void Start()
    {
        UpdateScoreText(); // Initialiser le texte d�s le d�part
    }

    public void AddCollectible(Collectible collectible)
    {
        _score += collectible.points; // Ajouter les points du collectible au score total
        UpdateScoreText(); // Mettre � jour le texte apr�s chaque collecte
    }

    private void UpdateScoreText()
    {
        _scoreText.text = $"Score: {_score} points"; // Afficher simplement le score total
    }
}


