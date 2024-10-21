using System.Collections;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    [SerializeField] private Rigidbody2D _rb;
    [SerializeField] private float _acceleration = 5f;
    [SerializeField] private float _maxSpeed = 10f;
    [SerializeField] private float _speed = 0f;
    [SerializeField] private float _jumpForce = 5f; // Force du saut
    [SerializeField] private Transform _groundCheck; // Position pour vérifier si le personnage est au sol
    [SerializeField] private LayerMask _groundLayer; // Masque de couche pour détecter le sol
    [SerializeField] private Animator _animator; // Référence à l'Animator

    private float _groundCheckRadius = 3f; // Rayon pour vérifier le sol
    private bool _isGrounded;
    private bool _isJumping = false;
    private bool _isWalking = false;

    private float _rotationSpeed = 5f; // Vitesse de rotation
    private float _angle = 0f; // Angle de rotation

    void Update()
    {
        HandleMovement();

        // Vérifie si le personnage est au sol et si la touche Espace est pressée pour sauter
        if (_isGrounded && !_isJumping && Input.GetKeyDown(KeyCode.Space))
        {
            Jump();
        }

        // Mise à jour de l'animation en fonction de l'état du personnage
        _animator.SetBool("is_jumpping", _isJumping);
        _animator.SetBool("is_walking", _isWalking);
    }

    void FixedUpdate()
    {
        // Appliquer le mouvement calculé au Rigidbody2D
        _rb.velocity = new Vector2(_speed, _rb.velocity.y);

        // Création d'un Raycast pour détecter le sol
        RaycastHit2D hitGround = Physics2D.Raycast(_groundCheck.position, Vector2.down, _groundCheckRadius, _groundLayer);
        _isGrounded = hitGround.collider != null;

        
        // Visualiser le Raycast dans l'éditeur Unity (facultatif pour le débogage)
        Debug.DrawRay(_groundCheck.position, Vector2.down * _groundCheckRadius, Color.red);
    }

    private void HandleMovement()
    {
        _isWalking = false;
        // Mouvement vers la droite
        if (Input.GetKey(KeyCode.RightArrow))
        {
            _isWalking = true;
            _speed += _acceleration * Time.deltaTime;
            _speed = Mathf.Clamp(_speed, 0, _maxSpeed); // Limiter la vitesse maximale
            _angle += _rotationSpeed; // Tourne vers la droite
        }
        // Mouvement vers la gauche
        else if (Input.GetKey(KeyCode.LeftArrow))
        {
            _isWalking = true;
            _speed -= _acceleration * Time.deltaTime;
            _speed = Mathf.Clamp(_speed, -_maxSpeed, 0); // Limiter la vitesse maximale
            _angle -= _rotationSpeed; // Tourne vers la gauche
        }
        else
        {
            // Ralentir progressivement si aucune touche n'est pressée
            _speed = Mathf.MoveTowards(_speed, 0, _acceleration * Time.deltaTime);
           
        
        }
    }

   

    private void Jump()
    {
        _isJumping = true; // Définir le paramètre de saut comme vrai
        _rb.velocity = new Vector2(_rb.velocity.x, _jumpForce);
        StartCoroutine(WaitForJumpToEnd());
        Debug.Log("Je saute");
    }

    private IEnumerator WaitForJumpToEnd()
    {
        // Attendre que l'animation de saut se termine avant de permettre un autre saut
        while (_animator.GetCurrentAnimatorStateInfo(0).IsName("idle_jump"))
        {
            yield return null; // Attendre la fin de l'animation de saut
        }
        _isJumping = false; // Le saut est terminé, permettre un autre saut
    }

    private void OnDrawGizmosSelected()
    {
        // Visualiser le point de détection au sol dans l'éditeur Unity
        if (_groundCheck != null)
        {
            Gizmos.color = Color.red;
            Gizmos.DrawWireSphere(_groundCheck.position, _groundCheckRadius);
        }
    }
}
