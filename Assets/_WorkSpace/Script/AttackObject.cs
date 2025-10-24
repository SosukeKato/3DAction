using UnityEngine;

public class AttackObject : MonoBehaviour
{
    EnemyHealth _health;

    [SerializeField]
    float _damage;
    private void OnTriggerEnter(Collider trg)
    {
        _health = trg.gameObject.GetComponent<EnemyHealth>();
        _health._nowHP -= _damage;
    }
}
