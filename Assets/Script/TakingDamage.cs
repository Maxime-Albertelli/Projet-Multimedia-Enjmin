using TMPro;
using UnityEngine;

public class TakingDamage : MonoBehaviour
{
    [SerializeField] int pv;
    [SerializeField] Canvas deathMenu;
    [SerializeField] TMP_Text pvText;
    float invulnerabilityCooldown = 0.75f;
    float lastHit;

    private void Start()
    {
        deathMenu.enabled = false;
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

    private void Update()
    {
        pvText.text = pv.ToString(); 
        if (pv <= 0) {
            Time.timeScale = 0;
            gameObject.GetComponent<CharacterMvmt>().enabled = false;
            deathMenu.enabled = true;
        }
    }
}
