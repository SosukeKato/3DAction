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

        #region �L�����N�^�[�̈ړ�
        x = Input.GetAxisRaw("Horizontal");
        z = Input.GetAxisRaw("Vertical");
        _velocity = new Vector3(x, y, z);
        _rb.velocity = _velocity * _moveSpeed;
        #endregion

        #region Raycast�g�p����
        //Ray�̔��ˈʒu�Ȃǂ��Ǘ�����ϐ�
        _origin = _tr.position;
        _under = Vector3.down;
        _front = Vector3.forward;
        #region �W�����v�̏���
        //Ray���g�����ڒn����
        RaycastHit _onGround;
        //�ڒn���̏���
        if (Physics.Raycast(_origin,_under,out _onGround,_rayUnderDistance))
        {
            //�W�����v�̏���
            if (Input.GetKeyDown(KeyCode.Space))
            {
                _rb.AddForce(0, _jumpPower, 0);
            }
        }
        Debug.DrawRay(_origin, _under * _rayUnderDistance, Color.red);
        #endregion

        #region �U���̏���
        //Ray�̏ՓˊǗ�
        RaycastHit _attackRange;
        #endregion

        #endregion

        #endregion
    }
}
