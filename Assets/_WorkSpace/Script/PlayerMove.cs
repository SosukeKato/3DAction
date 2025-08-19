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
    int _jumpPower;
    [SerializeField]
    float _rayFrontDistance;
    [SerializeField]
    float _rayUnderDistance;
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

        #region Raycast使用処理
        //Rayの発射位置などを管理する変数
        _origin = _tr.position;
        _under = Vector3.down;
        _front = Vector3.forward;
        #region ジャンプの処理
        //Rayを使った接地判定
        RaycastHit _onGround;
        //接地中の処理
        if (Physics.Raycast(_origin,_under,out _onGround,_rayUnderDistance))
        {
            //ジャンプの処理
            if (Input.GetKeyDown(KeyCode.Space))
            {
                _rb.AddForce(0, _jumpPower, 0);
            }
        }
        Debug.DrawRay(_origin, _under * _rayUnderDistance, Color.red);
        #endregion

        #region 攻撃の処理
        //Rayの衝突管理
        RaycastHit _attackRange;
        #endregion

        #endregion

        #endregion
    }
}
