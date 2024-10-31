using UnityEngine;

public class Collectible : MonoBehaviour
{
    [SerializeField] private int _points = 1;
    [SerializeField] private CollectibleType _collectibleType;
    [SerializeField] private float _jumpForceIncrease = 0f;
    [SerializeField] private ScoreManager _scoreManager;
    [SerializeField] private AudioSource _audioSource; 

    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.CompareTag("Player"))
        {
            
            if (_audioSource != null)
            {
                _audioSource.Play();
            }

            
            PlayerController playerController = other.GetComponent<PlayerController>();
            if (playerController != null)
            {
                playerController.IncreaseJumpForce(_jumpForceIncrease);
            }

            
            ScoreManager scoreManager = FindObjectOfType<ScoreManager>();
            if (scoreManager != null)
            {
                scoreManager.AddScore(this);
            }

            
            Destroy(gameObject, _audioSource.clip.length); 
        }
    }

    public int points => _points;
    public CollectibleType collectibleType => _collectibleType;
    public float jumpForceIncrease => _jumpForceIncrease;
}
