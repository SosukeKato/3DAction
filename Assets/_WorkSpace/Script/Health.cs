using UnityEngine;

public class Health : MonoBehaviour
{
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
            //キャラクターの死亡処理
        }
    }
}
