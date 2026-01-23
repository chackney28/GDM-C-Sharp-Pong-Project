using UnityEngine;

public class BallMovement : MonoBehaviour
{
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        Rigidbody2D rb = GetComponent<Rigidbody2D>();
        rb.velocity = new Vector2(3f, 3f);
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    void OnCollisionEnter2D(Collision2D collision)
    {
        Rigidbody2D rb = GetComponent<Rigidbody2D>();
            

        // Reverse direction, will have to make more complex later to make it bounce like how pong does
        rb.velocity = new Vector2(rb.velocity.x, -rb.velocity.y);
    }
}
