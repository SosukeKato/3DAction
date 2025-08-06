using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMove : MonoBehaviour
{
    Rigidbody _rb;
    Transform _tr;

    float x;
    float y;
    float z;
    Vector3 _velocity;

    [SerializeField]
    float _moveSpeed;
    void Start()
    {
        _tr = transform;
        _rb = GetComponent<Rigidbody>();
    }
    void Update()
    {
        x = Input.GetAxisRaw("Horizontal");
        z = Input.GetAxisRaw("Vertical");

        _velocity = new Vector3(x, y, z);
        _rb.velocity = _velocity * _moveSpeed;
    }
}
