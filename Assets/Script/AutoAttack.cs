using UnityEngine;

public class AutoAttack : MonoBehaviour
{
    [SerializeField] float attackSpeed;
    [SerializeField] GameObject attackHitBox;
    float lastAttack;
    bool isAttackActive;
    const float attackDuration = 0.40f;
    float attackBeginning;
    [SerializeField] float autoAttackRange;
    CapsuleCollider hitBox;
    [SerializeField] Transform attackEffect; 

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        hitBox = attackHitBox.GetComponent<CapsuleCollider>();
        isAttackActive = false;
        attackHitBox.SetActive(false);
    }

    // Update is called once per frame
    void Update()
    {
        hitBox.radius = autoAttackRange;
        attackEffect.transform.localScale = new Vector3(autoAttackRange*2,1,autoAttackRange*2);
        if(Time.time - lastAttack > attackSpeed)
        {
            Vector3 playerEmplacemennt = gameObject.transform.position;
            isAttackActive=true;
            attackHitBox.transform.position = playerEmplacemennt;
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
