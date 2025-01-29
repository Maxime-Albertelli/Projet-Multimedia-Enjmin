using UnityEngine;

public class EnemySpawning : MonoBehaviour
{
    [SerializeField] public GameObject enemyToInstantiate;
    float lastSpawn;
    [SerializeField] public float timeSinceLastSpawn;
    [SerializeField] public GameObject player;
    Transform cylinder;

    private void Start()
    {
        cylinder = gameObject.transform.GetChild(0);
    }

    // Update is called once per frame
    void Update()
    {
        if (Time.time - lastSpawn > timeSinceLastSpawn)
        {
            GameObject c = Instantiate(enemyToInstantiate, new Vector3(Random.Range((-cylinder.localScale.x / 3 + transform.position.x), (cylinder.localScale.x / 3 + transform.position.x)), transform.position.y + 2.5f, Random.Range((-cylinder.localScale.z / 3 + transform.position.z), (cylinder.localScale.z / 3 + transform.position.z))), transform.rotation);
            c.GetComponent<EnemyBehaviour>().setPlayer(player);
            lastSpawn = Time.time;
        }
    }

    public void setSpawnSpeed(float speed)
    {
        timeSinceLastSpawn = speed;
    }
}
