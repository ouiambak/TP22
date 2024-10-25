using UnityEngine;

public class CameraFollow : MonoBehaviour
{
    [SerializeField] private Transform _target; // L'objet à suivre
    [SerializeField] private Vector3 _offset; // Décalage de la caméra par rapport à l'objet suivi
    [SerializeField] private float _smoothSpeed = 0.125f; // Vitesse de lissage du mouvement de la caméra

    // Limites de la caméra (à ajuster selon votre jeu)
    [SerializeField] private float _minX = -4f; // Limite gauche
    [SerializeField] private float _maxX = 2.5f;  // Limite droite
    [SerializeField] private float _minY = -5f;  // Limite inférieure
    [SerializeField] private float _maxY = 5f;   // Limite supérieure

    private void Start()
    {
        // Initialiser le décalage selon la position de la caméra
        _offset = new Vector3(10, 10, -30); // Ajustez ceci pour placer la caméra dans le coin souhaité
    }

    private void LateUpdate()
    {
        // Vérifier que la cible est assignée
        if (_target != null)
        {
            // Calculer la position désirée
            Vector3 desiredPosition = _target.position + _offset;

            // Limiter la position de la caméra à l'intérieur des limites définies
            desiredPosition.x = Mathf.Clamp(desiredPosition.x, _minX, _maxX);
            desiredPosition.y = Mathf.Clamp(desiredPosition.y, _minY, _maxY);

            // Interpoler entre la position actuelle de la caméra et la position désirée pour un mouvement lisse
            Vector3 smoothedPosition = Vector3.Lerp(transform.position, desiredPosition, _smoothSpeed);

            // Mettre à jour la position de la caméra
            transform.position = smoothedPosition;
        }
    }
}
