using UnityEngine;

public class EnemyBehaviour : MonoBehaviour
{
    [SerializeField] public Transform player;
    [SerializeField] float enemySpeed;
    // Update is called once per frame
    void Update()
    {
        var step = enemySpeed * Time.deltaTime;
        transform.position = Vector3.MoveTowards(transform.position,player.transform.position, step);
    }
}
