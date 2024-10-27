using UnityEngine;

public class ZoneProtection : MonoBehaviour
{
    // Lorsque le héros entre dans la zone de protection
    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.CompareTag("Player"))
        {
            // Récupère le script du héros et active l'immunité
            PlayerController hero = other.GetComponent<PlayerController>();
            if (hero != null)
            {
                hero.SetImmunity(true);  // Activer l'immunité
                Debug.Log("Le héros est immunisé contre le feu.");
            }
        }
    }

    // Lorsque le héros sort de la zone de protection
    private void OnTriggerExit2D(Collider2D other)
    {
        if (other.CompareTag("Player"))
        {
            // Récupère le script du héros et désactive l'immunité
            PlayerController hero = other.GetComponent<PlayerController>();
            if (hero != null)
            {
                hero.SetImmunity(false);  // Désactiver l'immunité
                Debug.Log("Le héros n'est plus immunisé contre le feu.");
            }
        }
    }
}
