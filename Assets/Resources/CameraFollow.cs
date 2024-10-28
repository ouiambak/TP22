using UnityEngine;

public class CameraFollow : MonoBehaviour
{
    [SerializeField] private Transform _target;
    [SerializeField] private Vector3 _offset;
    [SerializeField] private float _smoothSpeed = 0.125f;


    [SerializeField] private float _minX = -4f;
    [SerializeField] private float _maxX = 2.5f;
    [SerializeField] private float _minY = -5f;
    [SerializeField] private float _maxY = 5f;

    private void Start()
    {

        _offset = new Vector3(10, 10, -30);
    }

    private void LateUpdate()
    {

        if (_target != null)
        {

            Vector3 desiredPosition = _target.position + _offset;


            desiredPosition.x = Mathf.Clamp(desiredPosition.x, _minX, _maxX);
            desiredPosition.y = Mathf.Clamp(desiredPosition.y, _minY, _maxY);


            Vector3 smoothedPosition = Vector3.Lerp(transform.position, desiredPosition, _smoothSpeed);


            transform.position = smoothedPosition;
        }
    }
}