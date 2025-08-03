using UnityEngine;

public class PlayerController : MonoBehaviour
{
    public float speed = 20f;


    
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
    }
    public void MoveTo()
    {
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
            ani.SetTrigger("isSit");
        }
    }
   
}
