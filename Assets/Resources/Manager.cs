using UnityEngine;
using TMPro; 

public class Manager : MonoBehaviour
{
    [SerializeField] private TextMeshProUGUI _playerNameText; 
    
    
    void Start()
    {   
        
        string playerName = PlayerPrefs.GetString("currentPlayer", "Joueur inconnu");

        
        Debug.Log("Nom du joueur : " + playerName);

        
        if (_playerNameText != null)
        {
            _playerNameText.text = "Nom : " + playerName;
        }
    }
}
