using UnityEngine;

public class AutoAttack : MonoBehaviour
{
    [SerializeField] float attackSpeed;
    [SerializeField] GameObject attackHitBox;
    float lastAttack;
    bool isAttackActive;
    const float attackDuration = 0.75f;
    float attackBeginning;

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        isAttackActive = false;
        attackHitBox.SetActive(false);
    }

    // Update is called once per frame
    void Update()
    {
        if(Time.time - lastAttack > attackSpeed)
        {
            isAttackActive=true;
            lastAttack = Time.time;
            attackBeginning = Time.time;
        }

        if (isAttackActive && Time.time - attackBeginning <= attackDuration) {
            attackHitBox.SetActive(true);
        }
        else if (isAttackActive && Time.time - attackBeginning > attackDuration)
        {
            attackHitBox.SetActive(false);
            isAttackActive =false;
        }
    }
}
