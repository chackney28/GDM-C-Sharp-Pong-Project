using UnityEngine;

public abstract class NetworkedObject : MonoBehaviour
{
    void Start()
    {
        
    }

    public abstract void getNetworkId();

    public abstract void Initalize();
}
