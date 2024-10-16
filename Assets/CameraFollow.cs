using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraFollow : MonoBehaviour
{
    [SerializeField] private Transform target; // L'objet que la caméra doit suivre
    private Vector3 offset= new Vector3(-1,-5,-25); // Décalage de la caméra par rapport à l'objet suivi
    [SerializeField] private float smoothSpeed = 0.125f; // Vitesse de suivi

    void LateUpdate()
    {
        // Calculer la position souhaitée de la caméra avec un décalage
        Vector3 desiredPosition = target.position + offset;

        // Lisser le mouvement de la caméra pour éviter des mouvements brusques
        Vector3 smoothedPosition = Vector3.Lerp(transform.position, desiredPosition, smoothSpeed);

        // Appliquer la nouvelle position à la caméra
        transform.position = smoothedPosition;
    }
}


