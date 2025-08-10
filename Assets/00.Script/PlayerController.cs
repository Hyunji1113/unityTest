using UnityEngine;

public class PlayerController : MonoBehaviour
{
    public float speed = 20f;
    public int playerHP = 100;

    bool isSitting = false;

    Vector3 move;
    Animator ani;

    void Start()
    {
      ani = GetComponentInChildren<Animator>();
    }

    void Update()
    {
        MoveTo();
        Look();
        Sit();
        Attack();
    }

    // ������ �����, �÷��̾ ������, �����̽��� �������� ���� �ִϸ��̼�
    
    // ���߿� ���Ⱑ ����� �ش� ����� weapon Ŭ���� ����, isTrigger ó��,
    // ontriggereEnter�� �Ʒ� �Լ� �̵� 
    private void OnCollisionEnter(Collision collision)
    {
        if(collision.gameObject.CompareTag("Enemy"))
        {
            collision.transform.GetComponent<Monster>().ReceiveHit(5);
        }
    }

    public void MoveTo()
    {
        if (isSitting == true)
        {
            ani.SetBool("isWalk", false);
            return;
        }
        float xAxis = Input.GetAxisRaw("Horizontal");
        float zAxis = Input.GetAxisRaw("Vertical");

        move = new Vector3(xAxis, 0, zAxis).normalized;

        transform.position += move * speed * Time.deltaTime;

        ani.SetBool("isWalk", move != Vector3.zero );  
        
    }

    public void Look()
    {
        transform.LookAt(transform.position+move);
    }

    public void Sit()
    {
        if (Input.GetKeyDown(KeyCode.LeftShift))
        {
            isSitting = !isSitting;
            ani.SetTrigger("isSit");        
        }
    }

    public void Attack()
    {
        if (Input.GetKeyDown(KeyCode.Space))
        {
            ani.SetBool("isAttack", true);
            transform.position += move * speed * Time.deltaTime;
        }
        else
        {
            ani.SetBool("isAttack", false);
        }
    }

    public void ReceiveHit(int hitDamage)
    {
        Debug.Log("hit hit" + hitDamage);
        playerHP -= hitDamage;
    }
}
