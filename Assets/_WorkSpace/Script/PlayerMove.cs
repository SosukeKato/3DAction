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
    Vector3 _origin;
    Vector3 _under;
    Vector3 _front;

    [SerializeField]
    float _moveSpeed;
    [SerializeField]
    float _rayFrontDistance;
    void Start()
    {
        _tr = transform;
        _rb = GetComponent<Rigidbody>();
    }
    void Update()
    {
        #region

        #region キャラクターの移動
        x = Input.GetAxisRaw("Horizontal");
        z = Input.GetAxisRaw("Vertical");
        _velocity = new Vector3(x, y, z);
        _rb.velocity = _velocity * _moveSpeed;
        #endregion

        #region 接地判定
        _origin = _tr.position;
        _under = Vector3.down;
        #endregion

        #endregion
    }
}
