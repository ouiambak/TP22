using UnityEngine;

public class MoveBackAndForth : MonoBehaviour
{
    [SerializeField] private float speed = 2f; // Vitesse du mouvement
    [SerializeField] private float distance = 2f; // Distance de l'aller-retour

    private Vector3 startPosition;

    void Start()
    {
        // Sauvegarde la position initiale de l'objet
        startPosition = transform.position;
    }

    void Update()
    {
        // Calcule la nouvelle position avec Mathf.PingPong pour faire l'aller-retour
        float movement = Mathf.PingPong(Time.time * speed, distance);
        transform.position = startPosition + Vector3.right * movement;
    }
}
