using System.Collections;
using UnityEngine;
using UnityEngine.Animations;

public class AutoAttack : MonoBehaviour
{
    [SerializeField] float attackSpeed;
    public int damage;
    private Animator animator;
    [SerializeField] private CapsuleCollider swordCollider;
    [SerializeField] GameObject attackAction;
    const float attackDuration = 0.5f;

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        animator = GetComponent<Animator>();
        swordCollider.enabled = false;
        StartCoroutine(AttackCoroutine());
    }
    private IEnumerator AttackCoroutine()
    {
        while (true)
        {
            animator.SetBool("isAttacking", true);
            swordCollider.enabled=true;
            yield return new WaitForSeconds(attackDuration);
            animator.SetBool("isAttacking", false);
            swordCollider.enabled=false;
            yield return new WaitForSeconds(attackSpeed);
        }
    }
}
