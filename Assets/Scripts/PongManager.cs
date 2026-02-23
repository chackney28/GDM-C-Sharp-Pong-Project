using Unity.Netcode;
using UnityEngine;
using TMPro;

public class PongManager : NetworkBehaviour
{
    public NetworkVariable<int> LeftPoints = new NetworkVariable<int>(0);
    public NetworkVariable<int> RightPoints = new NetworkVariable<int>(0);
    public NetworkVariable<float> yPositionLeft = new NetworkVariable<float>(0f);
    public NetworkVariable<float> yPositionRight = new NetworkVariable<float>(0f);
    
    //Below are a bunch of basic get and set methods to be able to connect the differing commands
    public void resetThings(){
        if (IsServer)
        {
            LeftPoints.Value = 0;
            RightPoints.Value = 0;
            yPositionLeft.Value = 0f;
            yPositionRight.Value = 0f;
        }
    }

    public int updateLeftScore(){
        if (IsServer){
            LeftPoints.Value++;
        }
        return LeftPoints.Value;
    }

    public int getLeftScore(){
        return LeftPoints.Value;
    }

    public int updateRightScore(){
        if (IsServer){
            RightPoints.Value++;
        }
        return RightPoints.Value;
    }

    public int getRightScore(){
        return RightPoints.Value;
    }
}