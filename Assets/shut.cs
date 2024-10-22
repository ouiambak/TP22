using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class shut : MonoBehaviour
{


    [SerializeField] private GameObject firePrefab; // R�f�rence au prefab de feu
    [SerializeField] private float spawnInterval = 2f; // Intervalle entre les instanciations
    private float lifetime = 3f;
    private void Start()
    {
        // D�marrer l'instanciation du feu
        InvokeRepeating(nameof(SpawnFire), 0f, spawnInterval);
       
    }

    private void SpawnFire()
    {
        // Instancier le feu � la position de l'objet vide avec une rotation par d�faut
        Instantiate(firePrefab, transform.position, Quaternion.identity);
        Destroy(gameObject, lifetime);
    }

}


