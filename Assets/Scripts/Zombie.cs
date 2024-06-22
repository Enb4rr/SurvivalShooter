using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Zombie : CharacterStats
{
    [SerializeField] public float Damage = 20f;
    private Animator animator;

    public Zombie(float healthPoints, float maxHealthPoints, bool isDead) : base(healthPoints, maxHealthPoints, isDead)
    {
    }

    private void Awake()
    {
        animator = GetComponent<Animator>();
    }

    public override void ReceiveDamage(float Damage)
    {
        base.ReceiveDamage(Damage);
        animator.SetBool("isWalking", false);
        animator.SetTrigger("ReceiveDamage");
    }

    public override void HandleDeath()
    {
        base.HandleDeath();
        animator.SetBool("isWalking", false);
        animator.SetBool("isDead", true);
    }

    public override void HandleRestart()
    {
        base.HandleRestart();
    }
}
