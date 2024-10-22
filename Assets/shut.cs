using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class shut : MonoBehaviour
{


    [SerializeField] private GameObject firePrefab; // Référence au prefab de feu
    [SerializeField] private float spawnInterval = 2f; // Intervalle entre les instanciations
    private float lifetime = 3f;
    private void Start()
    {
        // Démarrer l'instanciation du feu
        InvokeRepeating(nameof(SpawnFire), 0f, spawnInterval);
       
    }

    private void SpawnFire()
    {
        // Instancier le feu à la position de l'objet vide avec une rotation par défaut
        Instantiate(firePrefab, transform.position, Quaternion.identity);
        Destroy(gameObject, lifetime);
    }

}


