using System.Collections;
using UnityEngine;
using UnityEngine.SceneManagement;

public class PlayerController : MonoBehaviour
{
    [SerializeField] private Rigidbody2D _rb;
    [SerializeField] private float _acceleration = 5f;
    [SerializeField] private float _maxSpeed = 10f;
    [SerializeField] private float _speed = 0f;
    [SerializeField] private float _jumpForce = 5f; 
    [SerializeField] private Transform _groundCheck; 
    [SerializeField] private LayerMask _groundLayer; 
    [SerializeField] private Animator _animator; 
   
    private float _groundCheckRadius = 3f; 
    private bool _isGrounded;
    private bool _isJumping = false;
    private bool _isWalking = false;
    private bool isImmune = false;    


    private float _rotationSpeed = 5f; 
    private float _angle = 0f; 

    void Update()
    {
        HandleMovement();

        
        if (_isGrounded && !_isJumping && Input.GetKeyDown(KeyCode.Space))
        {
            Jump();
        }

       
        _animator.SetBool("is_jumpping", _isJumping);
        _animator.SetBool("is_walking", _isWalking);
    }

    void FixedUpdate()
    {
        
        _rb.velocity = new Vector2(_speed, _rb.velocity.y);

        RaycastHit2D hitGround = Physics2D.Raycast(_groundCheck.position, Vector2.down, _groundCheckRadius, _groundLayer);
        _isGrounded = hitGround.collider != null;

        Debug.DrawRay(_groundCheck.position, Vector2.down * _groundCheckRadius, Color.red);
    }

    private void HandleMovement()
    {
        _isWalking = false;
     
        if (Input.GetKey(KeyCode.RightArrow))
        {
            _isWalking = true;
            _speed += _acceleration * Time.deltaTime;
            _speed = Mathf.Clamp(_speed, 0, _maxSpeed); 
            _angle += _rotationSpeed; 
        }
        
        else if (Input.GetKey(KeyCode.LeftArrow))
        {
            _isWalking = true;
            _speed -= _acceleration * Time.deltaTime;
            _speed = Mathf.Clamp(_speed, -_maxSpeed, 0); 
            _angle -= _rotationSpeed; 
        }
        else
        {
           
            _speed = Mathf.MoveTowards(_speed, 0, _acceleration * Time.deltaTime);


        }
    }



    private void Jump()
    {
        _isJumping = true; 
        _rb.velocity = new Vector2(_rb.velocity.x, _jumpForce);
        StartCoroutine(WaitForJumpToEnd());
        Debug.Log("Je saute");
    }

    private IEnumerator WaitForJumpToEnd()
    {
        
        while (_animator.GetCurrentAnimatorStateInfo(0).IsName("idle_jump"))
        {
            yield return null; 
        }
        _isJumping = false; 
    }

    private void OnDrawGizmosSelected()
    {
        
        if (_groundCheck != null)
        {
            Gizmos.color = Color.red;
            Gizmos.DrawWireSphere(_groundCheck.position, _groundCheckRadius);
        }
    }
    public void IncreaseJumpForce(float amount)
    {
        _jumpForce += amount; 
        Debug.Log("Jump force increased: " + _jumpForce);
    }
    
    private void OnCollisionEnter2D(Collision2D collision)
    {
        
        if (collision.gameObject.GetComponent<FireOn>() != null && !isImmune)
        {
            GameOver();
        }
    }


    void GameOver()
    {
        Debug.Log("Game Over!");
        
        SceneManager.LoadScene(SceneManager.GetActiveScene().name);
    }
    
    public void SetImmunity(bool immunityStatus)
    {
        isImmune = immunityStatus;  
    }
}
