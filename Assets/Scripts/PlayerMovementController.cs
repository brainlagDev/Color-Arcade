using UnityEngine;
public class PlayerMovementController : MonoBehaviour
{
    private bool isGrounded;
    private bool isRunning;
    public int MovementSpeed;
    public int JumpForce;
    private void Awake()
    {
        isGrounded = false;
        isRunning = false;
        MovementSpeed = 4;
        JumpForce = 20000;
    }
    private void Update()
    {
        Vector3 direction = new Vector3(0, 0, 0);
        if ((Input.GetAxis("Jump") != 0) && (isGrounded == true))
        {
            isGrounded = false;
            this.GetComponent<Rigidbody2D>().AddForce(new Vector2(0, JumpForce));
        }
        if ((Input.GetAxis("Horizontal") != 0))
        {
            if (isGrounded == true)
            {
                direction += transform.right * Input.GetAxis("Horizontal");
                transform.gameObject.GetComponent<Rigidbody2D>().velocity = direction* MovementSpeed;
                GetComponent<Animator>().SetBool("isRunning", true);
                if (Input.GetAxis("Horizontal") < 0)
                {
                    GetComponent<SpriteRenderer>().flipX = true;
                }
                else
                {
                    GetComponent<SpriteRenderer>().flipX = false;
                }
                isRunning = true;
            }
            else
            {
                GetComponent<Animator>().SetBool("isRunning", false);
                isRunning = false;
            }
        }
        else
        {
            GetComponent<Animator>().SetBool("isRunning", false);
            isRunning = false;
        }
    }
    /*private void OnCollisionStay2D(Collision2D collision)
    {
        isGrounded = true;
        GetComponent<Animator>().SetBool("isGrounded", true);
        GetComponent<Animator>().SetBool("isJumping", false);
        Debug.Log(collision.otherCollider.name);
    }*/
    /*private void OnTriggerStay(Collider other)
    {
        isGrounded = true;
        GetComponent<Animator>().SetBool("isGrounded", true);
        GetComponent<Animator>().SetBool("isJumping", false);
        Debug.Log(other.name);
    }*/
    /*private void OnTriggerEnter2D(Collider2D collision)
    {
        Debug.Log(collision.name);
    }*/
    private void OnTriggerStay2D(Collider2D collision)
    {
        isGrounded = true;
        GetComponent<Animator>().SetBool("isGrounded", true);
        GetComponent<Animator>().SetBool("isJumping", false);
    }
    /*private void OnCollisionExit2D(Collision2D collision)
    {
        GetComponent<Animator>().SetBool("isGrounded", false);
        GetComponent<Animator>().SetBool("isJumping", true);
    }*/
    private void OnTriggerExit2D(Collider2D collision)
    {
        //isGrounded = false;
        if(isRunning==true)
        {
            isGrounded = false;
        }
        GetComponent<Animator>().SetBool("isGrounded", false);
        GetComponent<Animator>().SetBool("isJumping", true);
    }
}
