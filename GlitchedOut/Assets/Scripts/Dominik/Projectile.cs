using UnityEngine;

public class Projectile : MonoBehaviour
{

    public Vector2 direction;
    public float speed;

    Rigidbody2D rb;

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
       rb = GetComponent<Rigidbody2D>(); 
    }

    // Update is called once per frame
    void FixedUpdate()
    {
        
        rb.linearVelocity = new Vector2 (direction.x * speed, direction.y*speed);
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.CompareTag("Wall"))
        {
            Destroy(gameObject);
        }
    }
}
