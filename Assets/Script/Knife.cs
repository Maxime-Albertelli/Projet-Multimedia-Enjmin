using UnityEngine;

public class Knife : MonoBehaviour
{
    public int damage;

    private void OnTriggerEnter(Collider other)
    {
        if (other.tag == "Enemy")
        {
            other.GetComponent<BasicEnemy>().TakingDamage(5);
            Destroy(gameObject);
        }
        else if (other.tag != "Player")
        {
            Destroy(gameObject);
        }
    }
}
