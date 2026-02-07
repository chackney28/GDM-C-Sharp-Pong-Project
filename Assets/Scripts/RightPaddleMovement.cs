using UnityEngine;

public class RightPaddleMovement : PlayerControllar, ICollidable
{
    //An extention so the paddles can be seperate from each other
    void Start()
    {
        
    }

    //A method that makes the ball move a certain way upon colliding with it
    public (float, float) OnHit(float velocityX, float velocityY){
        return (-3.0f, velocityY);
    }
}
