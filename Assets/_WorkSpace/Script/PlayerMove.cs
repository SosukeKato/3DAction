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

    #region 攻撃の処理に使う変数
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

        #region キャラクターの移動
        _move = new Vector3(Input.GetAxisRaw("Horizontal"), 0, Input.GetAxisRaw("Vertical"));
        _tr.position += new Vector3(_move.x * Time.deltaTime * _moveSpeed, _move.y, _move.z * Time.deltaTime * _moveSpeed);
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
        //Rayの衝突で攻撃のヒット判定を管理する変数
        RaycastHit _hitEnemy;
        //攻撃が当たる距離の処理
        if (Physics.Raycast(_origin,_front,out _hitEnemy,_rayFrontDistance))
        {
            //攻撃の処理
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
