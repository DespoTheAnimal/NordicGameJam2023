using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class HealthBar : MonoBehaviour
{

    //SÆTTES PÅ PLANETEN

    public Image healthBar;
    private float _healthAmount = 100f;

    private float _damage;

    MeteorScript MT;

    private void Awake()
    {
        MT = GetComponent<MeteorScript>();

        _damage = MT.asteroidDamage;
    }

    private void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.tag == "Asteroid")
        {
            TakeDamage(_damage);
        }
    }

    public void TakeDamage(float damage)
    {
        _healthAmount -= damage;
        healthBar.fillAmount = _healthAmount / 100f;
    }

    public void Heal(float healingAmount)
    {
        _healthAmount += healingAmount;
        _healthAmount = Mathf.Clamp(_healthAmount, 0, 100);

        healthBar.fillAmount = _healthAmount / 100f;
    }
}
