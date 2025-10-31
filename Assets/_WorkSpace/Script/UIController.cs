using UnityEngine;
using UnityEngine.UI;

public class UIController : MonoBehaviour
{
    PlayerHealth _ph;

    [SerializeField]
    Image _buffGauge;
    [SerializeField]
    Image _lifeBar;
    void Start()
    {
        _ph = GameObject.FindGameObjectWithTag("Player").GetComponent<PlayerHealth>();
    }

    void Update()
    {
        _lifeBar.fillAmount = _ph._nowHP / 100;
    }
}
