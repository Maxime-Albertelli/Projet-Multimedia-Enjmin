using System.Collections;
using Unity.VisualScripting;
using UnityEngine;

public class AutoAttackDealDamage : MonoBehaviour
{

    private void OnCollisionEnter(Collision other)
    {
        if (other.gameObject.tag == "Enemy")
        {
            GameObject collisionObject = other.gameObject;
            collisionObject.GetComponent<BasicEnemy>().TakingDamage(5);
            Vector3 pushVector = (collisionObject.transform.position - transform.position).normalized;
            StartCoroutine(pushEnemy(pushVector,collisionObject));
        }
    }

    private IEnumerator pushEnemy(Vector3 pushForce, GameObject enemy)
    {
        enemy.GetComponent<EnemyBehaviour>().enabled = false;
        enemy.GetComponent<Rigidbody>().AddForce(pushForce * 5f, ForceMode.Impulse);
        yield return new WaitForSeconds(0.5f);
        try
        {
            enemy.GetComponent<EnemyBehaviour>().enabled = true;
        }
        catch
        {
            print("Déjà suppr");
        }
    }
}
