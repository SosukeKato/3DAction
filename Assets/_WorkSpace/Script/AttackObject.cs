using UnityEngine;

public class AttackObject : MonoBehaviour
{
    GameObject _hitObj;
    private void OnTriggerEnter(Collider trg)
    {
        _hitObj = trg.gameObject;
    }
}
