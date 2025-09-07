using System.Collections;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.AI;
using UnityEngine.UIElements;

public class Monster : MonoBehaviour
{
    public Transform player;
    public float attackRange = 0.5f;
    public int monsterHP = 4;
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
        monsterHP -= hitDamage;
        if (monsterHP < 0)
        {
            anim.SetTrigger("Die");
            StartCoroutine(WaitDestroy());

            DropItem(GetRandomItem(), transform.position);
            //Destroy(gameObject);
        }
    }
  
    

    IEnumerator WaitDestroy()
    {
        yield return new WaitForSeconds(5f); // 하드코딩 변경하기
        Destroy(this.gameObject);
    }

    GameObject target;


    private void Update()
    {
        TrackPlayer();

        //if(시작을 감지할 bool 변수)
        //Ray ray = Camera.main.ScreenPointToRay(Input.mousePosition);
        //RaycastHit hit;

        //if (Physics.Raycast(ray, out hit))
        //{
        //    //f(만약에 바닥이냐 아니면 건물이냐 )
        //    // {

        //    //
        //    if(target == null)
        //    {
        //        //target = Instantaitle(건물프리팹); ( 이 코드는 한번만)
        //    }

        //    //target.trnasform,position = hit포지션;

        //    if(Input.GetMouseButtonDown(0))
        //    {
        //        설치
        //    }

        //}
    }

    /*
        private void Get건물메테리얼()
    {
       var meshRenderer 건물인스턴스.GetCopmonent<MeshRenderer>();
        Material copyMat = meshRenderer.materilas[0];
        Material originMat = meshRenderer.materilas[0];
        copyMat.color.a = 0.5f;
    meshRenderer.matirail[o]  = copyMat;

     meshRenderer.matirail[o]  = originMat;
    }
     */

    private void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.CompareTag("Player"))
        {
            PlayerController controller = collision.gameObject.GetComponentInParent<PlayerController>();

            if (controller != null)
            {
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

    public void DropItem(int uuid, Vector3 dropPosition)
    {
        Item itemToDrop = ItemAssetsInfo.Instance.ItemInfos.Find(item => item.GetUUID() == uuid);

        if (itemToDrop != null)
        {
            Instantiate(itemToDrop.GetPrefab(), dropPosition, Quaternion.identity);
        }
        else
        {
            Debug.LogWarning("해당 UUID의 아이템을 찾을 수 없습니다: ");
        }
        
    }

    private int GetRandomItem()
    {
        int randomValue = Random.Range(0, 101);

        if (randomValue < 50)
        {
            return 1001;
        }
        else if (randomValue < 80)
        {
            return 1002;
        }
        else
        {
            return 1003;
        }
    }
}

