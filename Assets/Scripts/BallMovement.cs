using System.Runtime.InteropServices;
using UnityEngine;
using Unity.Netcode;

public class BallMovement : NetworkBehaviour
{ 

    public NetworkVariable<bool> GameStarted = new NetworkVariable<bool>(false);
    public bool setOff = false;
    public GameObject clientMessage;

    //Sets the ball off in a random direction
    void Start()
    {
        
    }

    void Update()
    {
        Rigidbody2D rb = GetComponent<Rigidbody2D>();
        if (!GameStarted.Value){
            //Sets the velocity to 0 to make sure it doesn't move
            rb.linearVelocity = new Vector2(0, 0);
            setOff = false;
            //Checks to see how many things are connected, looking to see if both the host and client is connected
            if (NetworkManager.Singleton.ConnectedClientsList.Count > 1){
                GameStarted.Value = true;
                //Activates a message that tells the player they need someone else and won't continue without it
                clientMessage.gameObject.SetActive(false);
            }
        } else {
            //Sets ball off in a random direction
            if (!setOff){
                setOff = true;
                //Can't really be encapsulated because it needs to be placed into start
                float randomVelocityA = Random.Range(-6.0f, 6.0f);
                float randomVelocityB= Random.Range(-6.0f, 6.0f);
                rb.linearVelocity = new Vector2(randomVelocityA, randomVelocityB);
                transform.position = new Vector3(0, 0, 0);
            }
        }
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
