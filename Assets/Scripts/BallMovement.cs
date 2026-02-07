using System.Runtime.InteropServices;
using UnityEngine;

public class BallMovement : MonoBehaviour
{
    //Private attributes, not currently used but are here will be used potentially used later
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

    //public void OnHit(Collision2D collision){
        
    //}

    void OnCollisionEnter2D(Collision2D collision)
    {
        Rigidbody2D rb = GetComponent<Rigidbody2D>();
        
        //Very hacky way to achieve this, but it will check to see what it has collided with and then
        //do the movement accordingly
        //There is still a "bug" where the momentum slowly dies but that is something to consider when adding
        //interactions with the paddles proper
        float velocityChangeX = rb.linearVelocity.x;
        float velocityChangeY = rb.linearVelocity.y;
        if (velocityChangeX > 0 && velocityChangeX < 3){
            velocityChangeX = 3;
        } else if (velocityChangeX < 0 && velocityChangeX > -3){
            velocityChangeX = -3;
        }
        //A way to get if an object has an OnHit method and then execute it (mostly just changing the Ball velocity)
        ICollidable check = collision.gameObject.GetComponent<ICollidable>();
        if (check != null){
            (velocityChangeX, velocityChangeY) = check.OnHit(velocityChangeX, velocityChangeY);
        }

        rb.linearVelocity = new Vector2(velocityChangeX, velocityChangeY);
        
    }
}
