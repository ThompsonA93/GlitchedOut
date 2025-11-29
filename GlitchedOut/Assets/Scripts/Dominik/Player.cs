using UnityEngine;

public class Player : MonoBehaviour
{

    private Rigidbody2D rb;

    public float moveSpeed;
    public float jumpForce;

    public Transform groundCheck;
    public float groundCheckRadius= 0.2f;
    public LayerMask groundLayer;
    private bool isGrounded;


    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
    }

    // Update is called once per frame
    void Update()
    {

        //Move
        if (Input.GetKey(KeyCode.A))
        {
            rb.linearVelocity = new Vector2(-moveSpeed, rb.linearVelocity.y);
        }
        else if (Input.GetKey(KeyCode.D))
        {
            rb.linearVelocity = new Vector2(moveSpeed, rb.linearVelocity.y);
        }

        

        //Jump

        isGrounded = Physics2D.OverlapCircle(groundCheck.position, groundCheckRadius, groundLayer);

        if (isGrounded && Input.GetKeyDown(KeyCode.Space)) {
            rb.linearVelocity = new Vector2(rb.linearVelocity.x, jumpForce);
        }

        //Stop moving
        if (isGrounded) { 
            if (Input.GetKeyUp(KeyCode.A))
            {
                rb.linearVelocity = new Vector2(-moveSpeed / 3, rb.linearVelocity.y);
            }
            else if (Input.GetKeyUp(KeyCode.D))
            {
                rb.linearVelocity = new Vector2(moveSpeed / 3, rb.linearVelocity.y);
            }
        }


        //TODO: Flip sprite
    }
}
