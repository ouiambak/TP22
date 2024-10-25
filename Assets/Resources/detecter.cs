using UnityEngine;

public class detecter : MonoBehaviour
{
    [SerializeField] private LayerMask _Layer;
    public float _rotationSpeed = 50f;
    // Update is called once per frame
    void Update()
    {
        Vector3 origine = transform.position;
        Vector3 direction = transform.forward;
        Ray ray = new Ray(origine, direction);
        RaycastHit hit;

        Physics.Raycast(ray, out hit, 1000f, _Layer);
        
        float _collisionDistance = hit.distance;
        if (hit.collider == null)
        {
            Debug.DrawRay(origine, direction * 1000f, Color.red);
        }
        else
        {
            Debug.DrawRay(origine,direction*_collisionDistance, Color.red);
            Debug.Log(hit.point);
            Debug.Log(hit.collider.name);
        }
        transform.Rotate(0, _rotationSpeed * Time.deltaTime, 0);
    }
}
