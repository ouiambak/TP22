using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Move : MonoBehaviour
{
    [SerializeField] private Rigidbody2D _rb;
    [SerializeField] private float _acceleration = 5f;
    [SerializeField] private float _maxSpeed = 10f;
    [SerializeField] private float _speed = 0f;
    public float _jumpForce = 5f; // Force du saut
    // Update is called once per frame
    void Update()
    {
        // Avancer vers la droite quand on appuie sur la flèche droite
        if (Input.GetKey(KeyCode.LeftArrow))
        {
            _speed += _acceleration * Time.deltaTime;
            if (_speed >= _maxSpeed)
            {
                _speed = _maxSpeed;
            }
            _rb.velocity = new Vector2(_speed, _rb.velocity.y);
        }

        // Avancer vers la gauche quand on appuie sur la flèche gauche
        if (Input.GetKey(KeyCode.RightArrow))
        {
            _speed -= _acceleration * Time.deltaTime;
            if (_speed <= -_maxSpeed)
            {
                _speed = -_maxSpeed;
            }
            _rb.velocity = new Vector2(_speed, _rb.velocity.y);
        }

        // Si aucune touche n'est pressée, ralentir progressivement
        if (!Input.GetKey(KeyCode.RightArrow) && !Input.GetKey(KeyCode.LeftArrow))
        {
            _speed = Mathf.MoveTowards(_speed, 0, _acceleration * Time.deltaTime);
            _rb.velocity = new Vector2(_speed, _rb.velocity.y);
        }

        // Vérifie si l'objet est au sol et si la touche Espace est pressée
        if (Input.GetKeyDown(KeyCode.Space))
        {
            _rb.AddForce(Vector2.up * _jumpForce, ForceMode2D.Impulse);
  
            Debug.Log("je saute ");
        }

            // Vérifie quand l'objet touche le sol

        }
    
}
