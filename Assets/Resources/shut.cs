using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class shut : MonoBehaviour
{


    [SerializeField] private GameObject _firePrefab; // Référence au prefab de feu
    [SerializeField] private float _spawnInterval = 2f; // Intervalle entre les instanciations
    private float _lifetime = 3f;
    private void Start()
    {
        // Démarrer l'instanciation du feu
        InvokeRepeating(nameof(SpawnFire), 0f, _spawnInterval);
       
    }

    private void SpawnFire()
    {
        // Instancier le feu à la position de l'objet vide avec une rotation par défaut
        Instantiate(_firePrefab, transform.position, Quaternion.identity);
        Destroy(gameObject, _lifetime);
    }

}


