using UnityEngine;

public class TakingDamage : MonoBehaviour
{
    private void OnCollisionEnter(Collision collision)
    {
        Debug.Log("AAAAH");
        print("Collision sans le if");
        if (collision.gameObject.tag == "Player")
        {
            print("Collision avec if !");
        }
    }
}
