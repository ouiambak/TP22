using System.Collections;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    [SerializeField] private Rigidbody2D _rb;
    [SerializeField] private float _acceleration = 5f;
    [SerializeField] private float _maxSpeed = 10f;
    [SerializeField] private float _speed = 0f;
    [SerializeField] private float _jumpForce = 5f; // Force du saut
    [SerializeField] private Transform groundCheck; // Position pour vérifier si le personnage est au sol
    [SerializeField] private LayerMask groundLayer; // Masque de couche pour détecter le sol
    [SerializeField] private Animator animator; // Référence à l'Animator

    private float groundCheckRadius = 3f; // Rayon pour vérifier le sol
    private bool isGrounded;
    private bool isJumping = false; 

    void Update()
    {
        HandleMovement();

        // Vérifie si le personnage est au sol et si la touche Espace est pressée pour sauter
        if (isGrounded && !isJumping && Input.GetKeyDown(KeyCode.Space))
        {   
            Jump();
        }

        // Mise à jour de l'animation en fonction de l'état du personnage
        animator.SetBool("isJumping", isJumping);
    }

    void FixedUpdate()
    {
        // Appliquer le mouvement calculé au Rigidbody2D
        _rb.velocity = new Vector2(_speed, _rb.velocity.y);

        // Création d'un Raycast pour détecter le sol
        RaycastHit2D hitGround = Physics2D.Raycast(groundCheck.position, Vector2.down, groundCheckRadius, groundLayer);
        isGrounded = hitGround.collider != null;

        // Visualiser le Raycast dans l'éditeur Unity (facultatif pour le débogage)
        Debug.DrawRay(groundCheck.position, Vector2.down * groundCheckRadius, Color.red);
    }

    private void HandleMovement()
    {
        // Mouvement vers la droite
        if (Input.GetKey(KeyCode.RightArrow))
        {
            _speed += _acceleration * Time.deltaTime;
            _speed = Mathf.Clamp(_speed, 0, _maxSpeed); // Limiter la vitesse maximale
        }
        // Mouvement vers la gauche
        else if (Input.GetKey(KeyCode.LeftArrow))
        {
            _speed -= _acceleration * Time.deltaTime;
            _speed = Mathf.Clamp(_speed, -_maxSpeed, 0); // Limiter la vitesse maximale
        }
        else
        {
            // Ralentir progressivement si aucune touche n'est pressée
            _speed = Mathf.MoveTowards(_speed, 0, _acceleration * Time.deltaTime);
        }
    }

    private void Jump()
    {
        isJumping = true; // Définir le paramètre de saut comme vrai
        _rb.velocity = new Vector2(_rb.velocity.x, _jumpForce);
        StartCoroutine(WaitForJumpToEnd());
        Debug.Log("Je saute");
    }

    private IEnumerator WaitForJumpToEnd()
    {
        // Attendre que l'animation de saut se termine avant de permettre un autre saut
        while (animator.GetCurrentAnimatorStateInfo(0).IsName("idle_jump"))
        {
            yield return null; // Attendre la fin de l'animation de saut
        }
        isJumping = false; // Le saut est terminé, permettre un autre saut
    }

    private void OnDrawGizmosSelected()
    {
        // Visualiser le point de détection au sol dans l'éditeur Unity
        if (groundCheck != null)
        {
            Gizmos.color = Color.red;
            Gizmos.DrawWireSphere(groundCheck.position, groundCheckRadius);
        }
    }
}
