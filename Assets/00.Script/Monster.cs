using System.Collections;
using UnityEngine;
using UnityEngine.AI;

public class Monster : MonoBehaviour
{
    public Transform player;
    public float attackRange = 0.5f;
    public int monsterHP = 10;
    private NavMeshAgent agent;
    public float attackRange = 0.5f;

    Animator anim;

    void Start()
    {
        agent = GetComponent<NavMeshAgent>();
        anim = GetComponent<Animator>();    

       player = FindFirstObjectByType<PlayerController>().transform;
    }

    public void ReceiveHit(int hitDamage)
    {
        Debug.Log("Enemy hit hit" + hitDamage);
        monsterHP -= hitDamage;
        if (monsterHP < 0)
        {
            anim.SetTrigger("Die");
            StartCoroutine(WaitDestroy());
        }
    }

    IEnumerator WaitDestroy()
    {
        yield return new WaitForSeconds(5f); // 하드코딩 변경하기
        Destroy(this.gameObject);
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
