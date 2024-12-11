using UnityEngine;

public class TakingDamage : MonoBehaviour
{
    [SerializeField] int pv;
    float invulnerabilityCooldown = 0.75f;
    float lastHit;

    private void Start()
    {
        print("Points de vie : " + pv);
    }

    private void OnCollisionEnter(Collision collision)
    {
        if(Time.time -  lastHit > invulnerabilityCooldown)
        {
            if (collision.gameObject.tag == "Enemy")
            {
                print("Le jouer perd un point de vie");
                --pv;
                print("Points de vie : " + pv);
                lastHit = Time.time;
            }
        }
    }
}
