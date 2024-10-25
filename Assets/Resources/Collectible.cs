using UnityEngine;

public class Collectible : MonoBehaviour
{
    [SerializeField] private int _points = 1; // Points que cet objet rapporte
    [SerializeField] private CollectibleType _collectibleType; // Type de l'objet ramassable
    [SerializeField] private float _jumpForceIncrease = 0f; // Augmentation de la force de saut

    private void OnTriggerEnter2D(Collider2D other)
    {
        // Vérifier si l'objet qui entre en collision a le tag "Player"
        if (other.CompareTag("Player"))
        {
            // Augmenter la force de saut du joueur si applicable
            PlayerController playerController = other.GetComponent<PlayerController>();
            if (playerController != null)
            {
                playerController.IncreaseJumpForce(_jumpForceIncrease); // Appliquer l'augmentation de la force de saut
            }

            // Trouver le ScoreManager et ajouter les points
            ScoreManager scoreManager = FindObjectOfType<ScoreManager>();
            if (scoreManager != null)
            {
                scoreManager.AddCollectible(this); // Passer l'objet ramassé au ScoreManager
            }

            // Détruire le collectible après qu'il ait été ramassé
            Destroy(gameObject);
        }
    }

    // Getter pour les points
    public int points => _points;

    // Getter pour le type de collectible
    public CollectibleType collectibleType => _collectibleType;

    // Getter pour l'augmentation de la force de saut
    public float jumpForceIncrease => _jumpForceIncrease;
}
