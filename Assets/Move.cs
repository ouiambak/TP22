using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Move : MonoBehaviour
{
    [SerializeField] private Rigidbody2D _rb;
    [SerializeField] private float _acceleration = 5f;
    [SerializeField] private float _maxSpeed = 10f;
    [SerializeField] private float _speed = 0f;
    [SerializeField] private float _jumpForce = 5f; // Force du saut
    [SerializeField] private Transform groundCheck; // Position pour vérifier si le personnage est au sol
    [SerializeField] private LayerMask groundLayer; // Masque de couche pour détecter le sol

    private float groundCheckRadius = 0.2f; // Rayon pour vérifier le sol
    private bool isGrounded;
    private Vector2 _velocity;

    void Update()
    {
        HandleMovement();
        CheckGround();

        // V�rifie si le personnage est au sol et si la touche Espace est press�e pour sauter
        if (isGrounded && Input.GetKeyDown(KeyCode.Space))
        {
            Jump();
        }
    }

    private void FixedUpdate()
    {
        // Appliquer le mouvement calculé au Rigidbody2D
        _rb.velocity = new Vector2(_speed, _rb.velocity.y);
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
        _rb.velocity = new Vector2(_rb.velocity.x, _jumpForce);
        Debug.Log("je saute");
    }

    private void CheckGround()
    {
        // Vérifier si le personnage est au sol en utilisant un cercle
        isGrounded = Physics2D.OverlapCircle(groundCheck.position, groundCheckRadius, groundLayer);
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
