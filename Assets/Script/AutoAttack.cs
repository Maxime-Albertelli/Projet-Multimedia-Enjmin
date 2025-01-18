using UnityEngine;

public class AutoAttack : MonoBehaviour
{
    [SerializeField] float attackSpeed;
    public int damage;
    [SerializeField] GameObject attackAction;
    const float attackDuration = 0.40f;

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        InvokeRepeating("instantiateAutoAttack",attackSpeed,attackSpeed);
    }
    void instantiateAutoAttack()
    {
        Vector3 playerPos = transform.position;
        GameObject c = Instantiate(attackAction, transform.position, transform.rotation);
        Destroy(c, attackDuration);
    }
}
