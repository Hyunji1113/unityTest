using JetBrains.Rider.Unity.Editor;
using UnityEngine;
using UnityEngine.AI;

public class Monster : MonoBehaviour
{
    public Transform player;
    private NavMeshAgent agent;
    public float attackRange = 0.5f;

    Animator anim;

    void Start()
    {
        agent = GetComponent<NavMeshAgent>();
        anim = GetComponent<Animator>();    

       player = FindFirstObjectByType<PlayerController>().transform;
    }

    private void Update()
    {
        TrackPlayer();
    }

        if (distanceToPlayer < attackRange)
        {
            Debug.Log("Attack");
            anim.SetBool("isAttack", true);
        }

    public void TrackPlayer()
        {
        float distanceToPlayer = Vector3.Distance(player.position, transform.position);
      
        if (distanceToPlayer > attackRange && isAlive)
        {
            agent.SetDestination(player.position);

        }
        

    }
}
