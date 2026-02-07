using UnityEngine;

public class TopBarrierCollision : MonoBehaviour, ICollidable
{
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        
    }

    public (float, float) OnHit(float velocityX, float velocityY){
        return (velocityX, -3.0f);
    }
}
