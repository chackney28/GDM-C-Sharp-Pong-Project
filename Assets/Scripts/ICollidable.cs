using System.Diagnostics;
using UnityEngine;

public interface ICollidable
{
    //A method that calls OnHit things within objects. The (float, float) means it returns a tuple to simplify the process
    (float, float) OnHit(float velocityX, float velocityY);
}
