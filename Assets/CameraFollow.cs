using UnityEngine;

public class CameraFollow : MonoBehaviour
{
    [SerializeField] private Transform target; // L'objet à suivre
    [SerializeField] private Vector3 offset; // Décalage de la caméra par rapport à l'objet suivi
    [SerializeField] private float smoothSpeed = 0.125f; // Vitesse de lissage du mouvement de la caméra

    // Limites de la caméra (à ajuster selon votre jeu)
    [SerializeField] private float minX = -4f; // Limite gauche
    [SerializeField] private float maxX = 2.5f;  // Limite droite
    [SerializeField] private float minY = -5f;  // Limite inférieure
    [SerializeField] private float maxY = 5f;   // Limite supérieure

    private void Start()
    {
        // Initialiser le décalage selon la position de la caméra
        offset = new Vector3(10, 10, -30); // Ajustez ceci pour placer la caméra dans le coin souhaité
    }

    private void LateUpdate()
    {
        // Vérifier que la cible est assignée
        if (target != null)
        {
            // Calculer la position désirée
            Vector3 desiredPosition = target.position + offset;

            // Limiter la position de la caméra à l'intérieur des limites définies
            desiredPosition.x = Mathf.Clamp(desiredPosition.x, minX, maxX);
            desiredPosition.y = Mathf.Clamp(desiredPosition.y, minY, maxY);

            // Interpoler entre la position actuelle de la caméra et la position désirée pour un mouvement lisse
            Vector3 smoothedPosition = Vector3.Lerp(transform.position, desiredPosition, smoothSpeed);

            // Mettre à jour la position de la caméra
            transform.position = smoothedPosition;
        }
    }
}
