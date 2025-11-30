using System.Diagnostics;
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

    // Audio-related variables, 2 sources required as otherwise walking overwrites jumping/Collission
    public AudioSource playerAudioSource;      // For Walking
    public AudioSource sfxAudioSource;         // For one-shot SFX (Jump, Collision)
    public AudioClip jumpSound;
    public AudioClip moveSound;
    public AudioClip collisionSound;
    private bool isMovingSoundPlaying = false;

    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
        // Get ALL AudioSource components attached to the player
        AudioSource[] sources = GetComponents<AudioSource>();

        if (sources.Length >= 2)
        {
            playerAudioSource = sources[0];
            sfxAudioSource = sources[1];
        }

    }

    void Update()
    {
        bool isMoving = false;

        //Move
        if (Input.GetKey(KeyCode.A))
        {
            rb.linearVelocity = new Vector2(-moveSpeed, rb.linearVelocity.y);
            isMoving = true;
        }
        else if (Input.GetKey(KeyCode.D))
        {
            rb.linearVelocity = new Vector2(moveSpeed, rb.linearVelocity.y);
            isMoving = true;
        }

        //Jump
        isGrounded = Physics2D.OverlapCircle(groundCheck.position, groundCheckRadius, groundLayer);
        if (isGrounded && Input.GetKeyDown(KeyCode.Space))
        {
            rb.linearVelocity = new Vector2(rb.linearVelocity.x, jumpForce);
            if (sfxAudioSource != null)
            {
                sfxAudioSource.PlayOneShot(jumpSound);
            }
        }
        // Check for walking sound now
        if(isGrounded && isMoving)
        {
            if (!isMovingSoundPlaying) // Countercheck required or it will rerun play() on every frame resulting in 0 sfx
            {
                //playerAudioSource.PlayOneShot(moveSound); This only rapidly plays the sfx, needs proper looping
                playerAudioSource.loop = true; // Use another audio source to not block sfx
                playerAudioSource.clip = moveSound;
                playerAudioSource.Play();
                isMovingSoundPlaying = true;
            }
        } 
        else if (isMovingSoundPlaying && (!isGrounded || !isMoving)) 
        {
            playerAudioSource.Stop();
            isMovingSoundPlaying = false;
        }

        //Stop moving
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
}
