using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Health : MonoBehaviour
{
    public int health = 100;
    public void TakeDamage(int amount)
    {
        health -= amount;
        if(health <= 0)
        {
            Destroy(gameObject);
        }
    }
}
