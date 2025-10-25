using UnityEngine;

public class PlayerHealth : MonoBehaviour
{
    bool _isDealth;

    [SerializeField]
    float _maxHP;
    [SerializeField]
    public float _nowHP;

    public void Health()
    {
        if(_nowHP >= _maxHP)
        {
            _nowHP = _maxHP;
        }
        if(_nowHP <= 0)
        {

        }
    }
}
