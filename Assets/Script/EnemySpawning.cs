using UnityEngine;

public class EnemySpawning : MonoBehaviour
{
    [SerializeField] public GameObject enemyToInstantiate;
    private float playerZ;
    private float playerX;
    private float playerY;
    private int randomPlacement;
    float lastSpawn;
    [SerializeField] float timeSinceLastSpawn;
    [SerializeField] public GameObject player;
    // Update is called once per frame
    void Update()
    {
        playerZ = player.transform.position.z;
        playerX = player.transform.position.x;
        playerY = player.transform.position.y;
        randomPlacement = Random.Range(0, 2);
        if (Time.time - lastSpawn > timeSinceLastSpawn)
        {
            if (randomPlacement == 1)
            {
                GameObject c = Instantiate(enemyToInstantiate, new Vector3(Random.Range(-50.0f + transform.position.x, -2 + transform.position.x), transform.position.y + 2, Random.Range(-50.0f + transform.position.z, -60.0f + transform.position.z)), transform.rotation);
                c.GetComponent<EnemyBehaviour>().setPlayer(player);
            }
            else if (randomPlacement == 0)
            {
                GameObject c = Instantiate(enemyToInstantiate, new Vector3(Random.Range(-50.0f + transform.position.x, -2 + transform.position.x), transform.position.y + 2, Random.Range(50.0f + transform.position.z, 60.0f + transform.position.z)), transform.rotation);
                c.GetComponent<EnemyBehaviour>().setPlayer(player);
            }
            lastSpawn = Time.time;
        }
    }
}
