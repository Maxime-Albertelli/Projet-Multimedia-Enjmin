using UnityEngine;

public class BasicEnemy : MonoBehaviour
{
    public int hp;
    [SerializeField] GameObject exp;

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        hp = 10;
    }

    private void Update()
    {
        if (hp <= 0)
        {
            Destroy(gameObject);
            Instantiate(exp, transform.position, Quaternion.identity);
        }
    }

    public void TakingDamage(int damage)
    {
        if (hp > 0)
        {
            hp -= damage;
        }
    }
}
