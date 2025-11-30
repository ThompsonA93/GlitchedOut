using UnityEngine;

public class Player : MonoBehaviour
{
    private Rigidbody2D rb;

    public float moveSpeed;
    public float jumpForce;

    public LayerMask groundLayer;
    public Transform groundCheck;
    public float groundCheckRadius= 0.2f;
    private bool isGrounded;

    // Audio-related variables
    public AudioSource playerAudioSource; 
    public AudioClip jumpSound;           
    public AudioClip moveSound;
    public AudioClip collisionSound;
    private bool isMovingSoundPlaying = false;

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
        playerAudioSource = GetComponent<AudioSource>();
    }

    // Update is called once per frame
    void Update()
    {
        // Refactored :: Set checks at start to see if sounds play or not
        bool isMoving = false;
        isGrounded = Physics2D.OverlapCircle(groundCheck.position, groundCheckRadius, groundLayer);

        // Move & set flag for Walking SFX
        if (isGrounded && Input.GetKey(KeyCode.A))
        {
            rb.linearVelocity = new Vector2(-moveSpeed, rb.linearVelocity.y);
            isMoving = true;
        }
        else if (isGrounded && Input.GetKey(KeyCode.D))
        {
            rb.linearVelocity = new Vector2(moveSpeed, rb.linearVelocity.y);
            isMoving = true;
        }

        // Jump & play sfx
        if (isGrounded && Input.GetKeyDown(KeyCode.Space)) 
        {
            rb.linearVelocity = new Vector2(rb.linearVelocity.x, jumpForce);
            playerAudioSource.PlayOneShot(jumpSound);
        }

        // Not Jumping => Play walk SFX when grounded
        if (isGrounded && isMoving && !isMovingSoundPlaying) 
        {
            //playerAudioSource.PlayOneShot(moveSound); This only rapidly plays the sfx, needs proper looping
            playerAudioSource.loop = true;
            playerAudioSource.clip = moveSound;
            playerAudioSource.Play();           
            isMovingSoundPlaying = true;        
        } 
        else if (isMovingSoundPlaying && (!isGrounded || !isMoving)) 
        {
            playerAudioSource.Stop();
            isMovingSoundPlaying = false;
        }


        // Stop moving
        if (true) 
        { 
            if (Input.GetKeyUp(KeyCode.A))
            {
                rb.linearVelocity = new Vector2(-moveSpeed / 3, rb.linearVelocity.y);
            }
            else if (Input.GetKeyUp(KeyCode.D))
            {
                rb.linearVelocity = new Vector2(moveSpeed / 3, rb.linearVelocity.y);
            }
        }
    }

    void OnCollisionEnter2D(Collision2D collision)
    {
        const float minImpactVelocity = 3.0f; // Minimum collission force to play the sound
        if (collisionSound != null && collision.relativeVelocity.magnitude > minImpactVelocity)
        {
            float impactVolume = Mathf.Clamp(collision.relativeVelocity.magnitude / 10f, 0.2f, 1.0f);
            playerAudioSource.PlayOneShot(collisionSound, impactVolume);
        }
    }
}
