using UnityEngine;

public class BottomBarrierCollision : MonoBehaviour, ICollidable
{
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        
    }

    //A method that makes the ball move a certain way upon colliding with it
    public (float, float) OnHit(float velocityX, float velocityY){
        return (velocityX, 3.0f);
    }
}
