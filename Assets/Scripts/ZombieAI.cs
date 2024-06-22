using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class ZombieAI : MonoBehaviour
{
    [SerializeField] public float speed = 1.5f;
    [SerializeField] public float attackDistance = 1.5f;
    [SerializeField] public float attackCooldown = 2f;

    private Animator animator;
    private GameObject target;
    private Zombie character;
    private Player player;
    private bool isAttacking = false;

    void Start()
    {
        target = GameObject.FindGameObjectWithTag("Player");
        animator = GetComponent<Animator>();
        character = GetComponent<Zombie>();
        player = target.GetComponent<Player>();
    }

    void Update()
    {
        if(target != null && character.IsDead == false)
        {
            if(CalculateDistance() <= attackDistance)
            {
                Attack();
                animator.SetBool("isWalking", false);
                animator.SetTrigger("Attack");
            }
            else
            {
                Chase();
                animator.SetBool("isWalking", true);
            }
        }
    }

    private void Chase()
    {
        if (target != null)
        {
            transform.LookAt(target.transform.position);
            transform.Translate(Vector3.forward * Time.deltaTime * speed);
            var resetYPos = new Vector3(transform.position.x, 0f, transform.position.z);
            transform.position = resetYPos;
        }
    }

    private void Attack() 
    {
        if (target != null & !isAttacking)
        {
            isAttacking = true;
            animator.SetTrigger("Attack");
            player.ReceiveDamage(character.Damage);
            StartCoroutine(AttackCooldown());
        }
    }

    private float CalculateDistance() 
    {
        if(target != null)
        {
            var distance = Vector3.Distance(target.transform.position, transform.position);
            return distance;
        }
        else { return 0f; }
    }

    private IEnumerator AttackCooldown()
    {
        yield return new WaitForSeconds(attackCooldown);
        isAttacking = false;
    }
}
