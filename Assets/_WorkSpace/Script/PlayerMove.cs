using UnityEngine;

public class PlayerMove : MonoBehaviour
{
    Rigidbody _rb;
    Transform _tr;
    Health _hpt;

    Vector3 _move;
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

    #region �U���̏����Ɏg���ϐ�
    float _damageBuff = 1;

    [SerializeField]
    int _nAttackDamage;
    #endregion
    void Start()
    {
        _tr = transform;
        _rb = GetComponent<Rigidbody>();
    }
    void Update()
    {
        #region

        #region �L�����N�^�[�̈ړ�
        _move = new Vector3(Input.GetAxisRaw("Horizontal"), 0, Input.GetAxisRaw("Vertical"));
        _tr.position += new Vector3(_move.x * Time.deltaTime * _moveSpeed, _move.y, _move.z * Time.deltaTime * _moveSpeed);
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
        //Ray�̏Փ˂ōU���̃q�b�g������Ǘ�����ϐ�
        RaycastHit _hitEnemy;
        //�U���������鋗���̏���
        if (Physics.Raycast(_origin,_front,out _hitEnemy,_rayFrontDistance))
        {
            //�U���̏���
            if (Input.GetMouseButtonDown(0))
            {
                _hpt = _hitEnemy.collider.gameObject.GetComponent<Health>();
                _hpt._nowHP -= _nAttackDamage * _damageBuff;
            }
        }
        Debug.DrawRay(_origin, _front * _rayFrontDistance, Color.red);
        #endregion

        #endregion

        #endregion
    }
}
