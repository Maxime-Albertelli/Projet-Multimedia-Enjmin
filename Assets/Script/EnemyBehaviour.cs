using UnityEngine;
using UnityEngine.AI;

public class EnemyBehaviour : MonoBehaviour
{
    public GameObject player;
    [SerializeField] float enemySpeed;
    //NavMeshAgent agent;

    private void Start()
    {
        //agent = GetComponent<NavMeshAgent>();
        //agent.enabled = true;
    }

    // Update is called once per frame
    void Update()
    {
        var step = enemySpeed * Time.deltaTime;
        transform.position = Vector3.MoveTowards(transform.position,player.transform.position, step);
        //agent.SetDestination(player.transform.position);
        Quaternion orientation = Quaternion.LookRotation(player.transform.position - transform.position, Vector3.up);
        transform.rotation = orientation;
    }

    public void setPlayer(GameObject playerToFollow)
    {
        player = playerToFollow;
    }
}
