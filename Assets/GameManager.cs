using UnityEngine;
using TMPro; // Si vous utilisez TextMeshPro pour afficher le nom

public class GameManager : MonoBehaviour
{
    [SerializeField] private TextMeshProUGUI playerNameText; // UI pour afficher le nom du joueur (facultatif)

    void Start()
    {
        // Récupérer le nom du joueur à partir des PlayerPrefs
        string playerName = PlayerPrefs.GetString("PlayerName", "Joueur inconnu");

        // Afficher dans la console (utile pour le debug)
        Debug.Log("Nom du joueur : " + playerName);

        // Optionnel : Afficher le nom du joueur dans l'UI
        if (playerNameText != null)
        {
            playerNameText.text = "Nom : " + playerName;
        }
    }
}
