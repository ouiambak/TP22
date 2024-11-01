using UnityEngine;
using UnityEngine.SceneManagement;
using TMPro;

public class PlayerNameInput : MonoBehaviour
{
    [SerializeField] private TMP_InputField _nameInputField;
    [SerializeField] private ScoreManager _scoreManager;

    public void OnSubmit()
    {
        string playerName = _nameInputField.text.Trim(); 
        
        if (string.IsNullOrEmpty(playerName))
        {
            Debug.LogWarning("Le nom du joueur ne peut pas être vide !");
            
            return;
        }

        _scoreManager.SavePlayerScore(playerName); 
        SceneManager.LoadScene("Game_Stage 1");
    }
}
