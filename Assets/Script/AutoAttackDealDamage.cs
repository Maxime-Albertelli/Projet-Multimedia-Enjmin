using Unity.VisualScripting;
using UnityEngine;

public class AutoAttackDealDamage : MonoBehaviour
{
    
    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.tag == "Enemy")
        {
            other.GetComponent<BasicEnemy>().TakingDamage(5);
        }
    }
}
