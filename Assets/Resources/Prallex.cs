using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Prallex : MonoBehaviour
{
    private float _lenght, _startpos;
    public GameObject _cam;
    public float _parallaxEffect;
    void Start()
    {
        _startpos = transform.position.x;
        _lenght = GetComponent<SpriteRenderer>().bounds.size.x;
    }

   
    void FixedUpdate()
    {
        float dist = (_cam.transform.position.x * _parallaxEffect);
        transform.position = new Vector3(_startpos+dist, transform.position.y,transform.position.z);
    }
}
