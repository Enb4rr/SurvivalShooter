using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : CharacterStats
{
    public Player(float healthPoints, float maxHealthPoints, bool isDead) : base(healthPoints, maxHealthPoints, isDead)
    {
    }

    public override void ReceiveDamage(float Damage)
    {
        base.ReceiveDamage(Damage);
    }

    public override void HandleDeath()
    {
        base.HandleDeath();
    }

    public override void HandleRestart()
    {
        base.HandleRestart();
    }
}
