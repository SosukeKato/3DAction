using UnityEngine;

public class Health : MonoBehaviour
{
    [SerializeField]
    float _maxHP;
    [SerializeField]
    public float _playerHP;

    void Update()
    {
        if(_playerHP >= _maxHP)
        {
            _playerHP = _maxHP;
        }
        if(_playerHP < 0)
        {
            //キャラクターの死亡処理
        }
    }
}
