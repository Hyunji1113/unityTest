using System.Collections;
using UnityEngine;
using UnityEngine.AI;

public class Monster : MonoBehaviour
{
    public Transform player;
    public float attackRange = 0.5f;
    public int monsterHP = 10;

    private NavMeshAgent agent;

    private bool isAlive => monsterHP > 0;

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

    private void OnCollisionEnter(Collision collision)
    {
        Debug.Log("OnCollisionEntert");

        if (collision.gameObject.CompareTag("Player"))
        {
            Debug.Log("PlayerPlayer");
            PlayerController controller = collision.gameObject.GetComponentInParent<PlayerController>();

            if (controller != null)
            {
                Debug.Log("Attack");
                anim.SetBool("isAttack", true);
                controller.ReceiveHit(30);
            }
        }
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
