using UnityEngine;

public class AttackObject : MonoBehaviour
{
    Health _health;

    [SerializeField]
    float _damage;
    private void OnTriggerEnter(Collider trg)
    {
        _health = trg.gameObject.GetComponent<Health>();
        _health._nowHP -= _damage;
    }
}
