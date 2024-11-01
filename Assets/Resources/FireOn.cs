using System.Collections;
using UnityEngine;
using UnityEngine.SceneManagement;

public class FireOn : MonoBehaviour
{
    [SerializeField] private string _gameOverSceneName;
    [SerializeField] private Animator _playerAnimator;

    private bool _isGameOver = false;

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.CompareTag("Player") && !_isGameOver)
        {
            _isGameOver = true;

            if (_playerAnimator != null)
            {
                _playerAnimator.SetBool("is_die", true);
            }

            StartCoroutine(GameOverAfterDelay(1f));
        }
    }

    private IEnumerator GameOverAfterDelay(float delay)
    {
        yield return new WaitForSeconds(delay);
        SceneManager.LoadScene(_gameOverSceneName);
    }
}