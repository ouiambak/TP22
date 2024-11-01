using UnityEngine;
using TMPro; // Si vous utilisez TextMeshPro pour afficher le nom

public class Manager : MonoBehaviour
{
    [SerializeField] private TextMeshProUGUI _playerNameText; 
    
    
    void Start()
    {   
        
        string playerName = PlayerPrefs.GetString("PlayerName", "Joueur inconnu");

        
        Debug.Log("Nom du joueur : " + playerName);

        
        if (_playerNameText != null)
        {
            _playerNameText.text = "Nom : " + playerName;
        }
    }
}
