using UnityEngine;

[RequireComponent(typeof(Rigidbody))]
public class Player : MonoBehaviour
{
    Rigidbody _rb;
    Transform _tr;
    EnemyHealth _eHealth;
    Enemy _enemy;

    Vector3 _move;

    float _dashSpeed;
    float _noDamageTimer;
    public float _buffGauge;

    bool _isDash;

    [SerializeField]
    float _moveSpeed;
    [SerializeField]
    int _jumpPower;
    [SerializeField]
    float _noDamageTime = 0.3f;


    #region ray�̏����Ɏg���ϐ�
    Vector3 _origin;
    Vector3 _under;
    Vector3 _front;

    [SerializeField]
    Vector3 _underRaySize = new Vector3(1,1,1);
    [SerializeField]
    float _rayFrontDistance;
    [SerializeField]
    float _rayUnderDistance;
    #endregion

    #region �U���̏����Ɏg���ϐ�
    float _damageBuff = 1;

    [SerializeField]
    int _frontSkillDamage;
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
        _tr.position += new Vector3(_move.x * Time.deltaTime * _moveSpeed * _dashSpeed, _move.y, _move.z * Time.deltaTime * _moveSpeed * _dashSpeed);
        #endregion

        #region Cast�g�p����
        //Ray�̔��ˈʒu�Ȃǂ��Ǘ�����ϐ�
        _origin = _tr.position;
        _under = Vector3.down;
        _front = Vector3.forward;
        #region �W�����v�̏���
        //Ray���g�����ڒn����
        RaycastHit _onGround;
        //�ڒn���̏���
        if (Physics.BoxCast(_origin,_underRaySize,_under,out _onGround,Quaternion.identity,_rayUnderDistance))
        {
            //�W�����v�̏���
            if (Input.GetKeyDown(KeyCode.Space))
            {
                _rb.AddForce(0, _jumpPower, 0);
            }
        }
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
                _eHealth = _hitEnemy.collider.gameObject.GetComponent<EnemyHealth>();
                _eHealth._nowHP -= _frontSkillDamage * _damageBuff;
            }
        }
        Debug.DrawRay(_origin, _front * _rayFrontDistance, Color.red);
        #endregion

        #endregion

        #region �X�L������
        //�o�t��������X�L��
        if (Input.GetKeyDown(KeyCode.G) && _buffGauge >= 100)
        {
            _damageBuff = _buffGauge;
        }
        #endregion

        #region ����̏���
        if ((Input.GetKeyDown(KeyCode.LeftShift)) && ((_move.x != 0) || (_move.z != 0)))
        {
            _isDash = true;
            _enemy = FindAnyObjectByType<Enemy>();
            _enemy._beforeEnemyDamageBuff = _enemy._enemyDamageBuff;
            _enemy._enemyDamageBuff = 0;
        }
        #region �_�b�V���̏���
        if (_isDash && (_move.x == 0) && (_move.z == 0))
        {
            _isDash = false;
            _dashSpeed = 1;
            _noDamageTimer = 0;
        }
        if (_isDash)
        {
            _noDamageTimer += Time.deltaTime;
            if (_noDamageTimer >= _noDamageTime)
            {
                _enemy._enemyDamageBuff = _enemy._beforeEnemyDamageBuff;
            }
            _dashSpeed = 2;
        }
        #endregion

        #endregion

        #endregion
    }
}
