using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CharacterStats : MonoBehaviour
{
    [SerializeField] private float healthPoints = 0f;
    [SerializeField] private float maxHealthPoints = 0f;
    [SerializeField] private bool isDead;

    void Start()
    {
        healthPoints = maxHealthPoints;
    }

    public void ReceiveDamage(float Damage)
    {
        if (isDead) return;

        healthPoints -= Damage;
        if(healthPoints <= 0f)
        {
            healthPoints = 0f;
            isDead = true;
            HandleDeath();
        }
    }

    private void HandleDeath()
    {

    }

    private void HandleRestart() 
    {

    }
}
