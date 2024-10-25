using UnityEngine;

public class MoveBackAndForth : MonoBehaviour
{
    [SerializeField] private float _speed = 2f; // Vitesse du mouvement
    [SerializeField] private float _distance = 2f; // Distance de l'aller-retour

    private Vector3 _startPosition;

    void Start()
    {
        // Sauvegarde la position initiale de l'objet
        _startPosition = transform.position;
    }

    void Update()
    {
        // Calcule la nouvelle position avec Mathf.PingPong pour faire l'aller-retour
        float movement = Mathf.PingPong(Time.time * _speed, _distance);
        transform.position = _startPosition + Vector3.right * movement;
    }
}
