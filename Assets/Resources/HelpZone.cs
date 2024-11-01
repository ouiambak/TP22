using UnityEngine;

public class HelpZone : MonoBehaviour
{
    [SerializeField] private Color _protectionColor = Color.red; 
    [SerializeField] private float _protectionDuration = 3f;
    [SerializeField] private AudioSource _audioSource;
    [SerializeField] private AudioClip _powerSound;
    private Color _originalColor;
    private bool _isProtected = false; 
    private SpriteRenderer _playerRenderer; 

    private void OnTriggerEnter2D(Collider2D other)
    {
        
        if (other.CompareTag("Player") && !_isProtected)
        {
            
            _playerRenderer = other.GetComponent<SpriteRenderer>();

            if (_playerRenderer != null)
            {
                
                _originalColor = _playerRenderer.color;
                _audioSource.PlayOneShot(_powerSound);
                _playerRenderer.color = _protectionColor;
            }

            
            _isProtected = true;

  
            Physics2D.IgnoreLayerCollision(LayerMask.NameToLayer("Player"), LayerMask.NameToLayer("FireObstacle"), true);

            Invoke("RemoveProtection", _protectionDuration);
        }
    }

 
    private void RemoveProtection()
    {
        if (_playerRenderer != null)
        {
          
            _playerRenderer.color = _originalColor;
        }

      
        _isProtected = false;

       
       
        Physics2D.IgnoreLayerCollision(LayerMask.NameToLayer("Player"), LayerMask.NameToLayer("FireObstacle"), false);
    }
}
