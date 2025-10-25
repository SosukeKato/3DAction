using UnityEngine;

public class EnemyHealth : MonoBehaviour
{
    bool _isDeath = false;

    [SerializeField]
    float _maxHP;
    [SerializeField]
    public float _nowHP;
    public void Health()
    {
        if (_nowHP >= _maxHP)
        {
            _nowHP = _maxHP;
        }
        if (_nowHP < 0)
        {
            _isDeath = true;
        }
    }
}
