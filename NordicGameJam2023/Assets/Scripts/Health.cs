using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Health : MonoBehaviour
{
    public int health = 100;

    public Image healthBar;

    [SerializeField] GameObject onDeathEffect;
    public void TakeDamage(int amount)
    {
        health -= amount;
        healthBar.fillAmount = health / 100f;
        if (health <= 0)
        {
            if(onDeathEffect != null)
            {
                GameObject clone = Instantiate(onDeathEffect, transform.position, transform.rotation);
            }
            
            Destroy(gameObject);
        }
    }
}
