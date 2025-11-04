using UnityEngine;
using UnityEngine.UI;

public class UIController : MonoBehaviour
{
    PlayerHealth _ph;
    Player _pl;

    [SerializeField]
    Image _buffGauge;
    [SerializeField]
    Image _lifeBar;
    void Start()
    {
        _ph = GameObject.FindGameObjectWithTag("Player").GetComponent<PlayerHealth>();
        _pl = GameObject.FindGameObjectWithTag("Player").GetComponent <Player>();
    }

    void Update()
    {
        _lifeBar.fillAmount = _ph._nowHP / _ph._maxHP;
        _buffGauge.fillAmount = _pl._overDrive / 100;
    }
}
