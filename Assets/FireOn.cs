using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class FireOn : MonoBehaviour
{
   
    [SerializeField] private string gameOverSceneName = "GameOver";

    
    private void OnCollisionEnter2D(Collision2D collision)
    {
        
        if (collision.gameObject.CompareTag("Player"))
        {
            
            SceneManager.LoadScene(gameOverSceneName);
        }
    }
}




