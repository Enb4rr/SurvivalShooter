using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CharacterStats : MonoBehaviour
{
    [SerializeField] private float healthPoints = 0f;
    [SerializeField] private float maxHealthPoints = 0f;
    [SerializeField] private bool isDead;

    public CharacterStats(float healthPoints, float maxHealthPoints, bool isDead)
    {
        HealthPoints = healthPoints;
        MaxHealthPoints = maxHealthPoints;
        IsDead = isDead;
    }

    public float HealthPoints { get => healthPoints; set => healthPoints = value; }
    public float MaxHealthPoints { get => maxHealthPoints; set => maxHealthPoints = value; }
    public bool IsDead { get => isDead; set => isDead = value; }


    void Start()
    {
        HealthPoints = MaxHealthPoints;
    }

    public virtual void ReceiveDamage(float Damage)
    {
        if (IsDead) return;

        HealthPoints -= Damage;
        if(HealthPoints <= 0f)
        {
            HealthPoints = 0f;
            IsDead = true;
            HandleDeath();
        }
    }

    public virtual void HandleDeath()
    {

    }

    public virtual void HandleRestart() 
    {

    }
}
