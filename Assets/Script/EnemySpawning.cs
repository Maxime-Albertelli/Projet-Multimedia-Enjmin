using UnityEngine;

public class EnemySpawning : MonoBehaviour
{
    [SerializeField] public Transform enemyToInstantiate;
    [SerializeField] public GameObject playerCoordinates;
    private float playerZ;
    private float playerX;
    private int randomPlacement;
    float lastSpawn;
    [SerializeField] float timeSinceLastSpawn;

    // Update is called once per frame
    void Update()
    {
        playerZ = playerCoordinates.transform.transform.position.z;
        playerX = playerCoordinates.transform.transform.position.x;
        randomPlacement = Random.Range(0, 2);
        if (Time.time - lastSpawn > timeSinceLastSpawn)
        {
            if (randomPlacement == 1)
            {
                Instantiate(enemyToInstantiate, new Vector3(Random.Range(-50.0f + playerX, 50.0f + playerX), 4.5f, Random.Range(-50.0f + playerZ, -60.0f + playerZ)), transform.rotation);
            }
            else if (randomPlacement == 0)
            {
                Instantiate(enemyToInstantiate, new Vector3(Random.Range(-50.0f + playerX, 50.0f + playerX), 4.5f, Random.Range(50.0f + playerZ, 60.0f + playerZ)), transform.rotation);
            }
            lastSpawn = Time.time;
        }
    }
}
