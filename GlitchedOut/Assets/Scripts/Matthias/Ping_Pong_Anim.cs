using UnityEngine;

public class Ping_Pong_Anim : MonoBehaviour
{
    // Init Variables
    Animator animator;
    private Rigidbody2D rb;

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        // Set Variables
        rb = GetComponent<Rigidbody2D>();
        animator = GetComponent<Animator>();
    }

    // Update is called once per frame
    void Update()
    {
        //Set Animator Parameters
        animator.SetFloat("Move_X", rb.linearVelocity.x);
    }
}
