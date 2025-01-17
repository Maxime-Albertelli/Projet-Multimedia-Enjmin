using TreeEditor;
using UnityEngine;

public class KnifeThrow : MonoBehaviour
{
    [SerializeField] GameObject knife;

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        InvokeRepeating("instantiateKnife", 2.0f, 1.0f);
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    void instantiateKnife()
    {
        Vector3 playerPos = transform.position;
        GameObject c = Instantiate(knife,transform.position,transform.rotation);
        c.AddComponent<Rigidbody>();
        c.GetComponent<Rigidbody>().linearVelocity = c.transform.forward * 75;
        c.GetComponent<Rigidbody>().useGravity = false;
        Destroy(c,2);
    }
}
