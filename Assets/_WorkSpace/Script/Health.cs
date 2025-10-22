using UnityEngine;

public class Health : MonoBehaviour
{
    bool _isDeath;

    [SerializeField]
    float _maxHP;
    [SerializeField]
    public float _nowHP;

    void Update()
    {
        if(_nowHP >= _maxHP)
        {
            _nowHP = _maxHP;
        }
        if(_nowHP < 0)
        {
            _isDeath = true;
        }
    }
}
