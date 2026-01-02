using UnityEngine;
using UnityEngine.InputSystem;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class PlayerMoveScript : MonoBehaviour
{
    public float speed = 5f;
    private Vector2 moveInput;
    Rigidbody2D myRigidbody;

    public float jumpPower = 5f;
    private int jumpNum = 0;
    public int maxJumpNum = 1;
    Animator Anim;
   
    public int HP = 5;
    
    private int MaxHP;
    public Image HPBar;
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        myRigidbody = GetComponent<Rigidbody2D>();
        Anim = this.GetComponent<Animator>();
        MaxHP = HP;

    }

    public void OnMove(InputAction.CallbackContext context)
    {
        moveInput = context.ReadValue<Vector2>();
        if (context.started)
        {
            Anim.SetBool("Move", true);
        }
        if (context.canceled) 
        {
            Anim.SetBool("Move", false);
        }
    }

    void FixedUpdate()
    {
        myRigidbody.linearVelocity = new Vector2(moveInput.x * speed, myRigidbody.linearVelocity.y);
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.tag == "Enemy")
        {
           
            HP--;
            Debug.Log("nowhp = " + HP);
            HPBar.fillAmount = (float)HP / MaxHP;

            myRigidbody.linearVelocity = new Vector2(0, 20);
            if (HP == 0)
            {
               
            }
        }
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {

        if (collision.gameObject.tag == "Floor")
        {
            jumpNum = 0;
            Anim.SetBool("Jump", false);
        }
    }

    public void ONJump(InputAction.CallbackContext context) 
    {
        if(jumpNum < maxJumpNum && context.started)
        { 
            myRigidbody.linearVelocityY = 0;
            myRigidbody.AddForce(transform.up * jumpPower, ForceMode2D.Impulse);
            jumpNum++;
            Anim.SetBool("Jump", true);

        }
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
