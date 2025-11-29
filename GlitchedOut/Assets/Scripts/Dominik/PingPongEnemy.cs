using UnityEngine;

public class PingPongEnemy : MonoBehaviour
{


    public float moveSpeed;

    public int direction;

    public Transform groundCheckLeft;
    public Transform groundCheckRight;

    public Transform wallCheckLeft;
    public Transform wallCheckRight;

    public float groundCheckRadius = 0.2f;
    public LayerMask groundLayer;

    Rigidbody2D rb;


    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
    }

    // Update is called once per frame
    void FixedUpdate()
    {

        
        rb.linearVelocity = new Vector2(direction * moveSpeed, rb.linearVelocity.y);


        //Switch direction if edge is reached

        Transform groundCheck;

        if(direction == -1)
        {
            groundCheck = groundCheckLeft;
        }
        else
        {
            groundCheck = groundCheckRight;

        }

        bool isGrounded = Physics2D.OverlapCircle(groundCheck.position, groundCheckRadius, groundLayer);

       

        Transform wallCheck;

        if (direction == -1)
        {
            wallCheck = wallCheckLeft;
        }
        else
        {
            wallCheck = wallCheckRight;

        }

        bool isWallCollision = Physics2D.OverlapCircle(wallCheck.position, groundCheckRadius, groundLayer);

        if (!isGrounded || isWallCollision)
        {
            direction = -direction;

        }
    }

   

    private void OnCollisionEnter2D(Collision2D other)
    {
        //Switch direction if collides with wall
      /*  if (other.gameObject.CompareTag("Wall"))
        {
            direction = -direction;
        }*/
    }

    
}
