using UnityEngine;
using UnityEngine.UI; 
using UnityEngine.SceneManagement;
using TMPro;
public class PlayerNameInput : MonoBehaviour
{
    [SerializeField] private TMP_InputField _nameInputField; 
    [SerializeField] private ScoreManager _scoreManager;

    public void OnSubmit()
    {
        string playerName = _nameInputField.text;
        _scoreManager.SaveScore(playerName);
        SceneManager.LoadScene("Game_Stage 1");
    }
}
