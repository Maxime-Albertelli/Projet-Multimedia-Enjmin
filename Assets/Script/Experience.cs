using UnityEngine;

public class Experience : MonoBehaviour
{
    [SerializeField] int expValue;
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    private void OnTriggerEnter(Collider other)
    {
        if(other.gameObject.tag == "Player")
        {
            other.GetComponent<Levelling>().gainExperience(expValue);
            Destroy(gameObject);
        }
    }
}
