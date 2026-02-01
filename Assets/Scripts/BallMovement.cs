using System.Runtime.InteropServices;
using UnityEngine;

public class BallMovement : MonoBehaviour
{
    //Private attributes
    private float movementX = 3f;
    private float movementY = 3f;  

    //Sets the ball off in a random direction
    void Start()
    {
        //Can't really be encapsulated because it needs to be placed into start
        float randomVelocityA = Random.Range(-6.0f, 6.0f);
        float randomVelocityB= Random.Range(-6.0f, 6.0f);
        Rigidbody2D rb = GetComponent<Rigidbody2D>();
        rb.linearVelocity = new Vector2(randomVelocityA, randomVelocityB);
    }

    void FixedUpdate()
    {

    }

    void OnCollisionEnter2D(Collision2D collision)
    {
        Rigidbody2D rb = GetComponent<Rigidbody2D>();
        
        //Very hacky way to achieve this, but it will check to see what it has collided with and then
        //do the movement accordingly
        //There is still a "bug" where the momentum slowly dies but that is something to consider when adding
        //interactions with the paddles proper
        //It also does nothing when hitting the right and left barriers, which is intentional because that
        //will be used for scoring later. 
        float velocityChangeX = rb.linearVelocity.x;
        if (collision.gameObject.tag == "Right Paddle"){ velocityChangeX = -movementX; }
        if (collision.gameObject.tag == "Left Paddle"){ velocityChangeX = movementX; }
        float velocityChangeY = rb.linearVelocity.y;
        if (collision.gameObject.tag == "Top Barrier"){ velocityChangeY = -movementY; }
        if (collision.gameObject.tag == "Bottom Barrier"){ velocityChangeY = movementY; }

        rb.linearVelocity = new Vector2(velocityChangeX, velocityChangeY);
        
    }
}
