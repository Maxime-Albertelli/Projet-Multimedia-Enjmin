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
    [SerializeField] public Transform playerCoordinates;
    // Update is called once per frame
    void Update()
    {
        playerZ = playerCoordinates.position.z;
        playerX = playerCoordinates.position.x;
        playerY = playerCoordinates.position.y;
        randomPlacement = Random.Range(0, 2);
        if (Time.time - lastSpawn > timeSinceLastSpawn)
        {
            if (randomPlacement == 1)
            {
                Instantiate(enemyToInstantiate, new Vector3(Random.Range(-50.0f + playerX, -2 + playerX), playerY, Random.Range(-50.0f + playerZ, -60.0f + playerZ)), transform.rotation);
            }
            else if (randomPlacement == 0)
            {
                Instantiate(enemyToInstantiate, new Vector3(Random.Range(-50.0f + playerX, -2 + playerX), playerY, Random.Range(50.0f + playerZ, 60.0f + playerZ)), transform.rotation);
            }
            lastSpawn = Time.time;
        }
    }
}
