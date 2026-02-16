using System.Diagnostics;
using System.Runtime.CompilerServices;
using System.Security.Cryptography;
using System.Security.Cryptography.X509Certificates;
using UnityEngine;
using Unity.Netcode;

public abstract class PlayerControllar : NetworkBehaviour
{
    //Private Attribute setting
    //0 Because it can never move
    public float horizontalSpeed = 0f;
    public float verticalSpeed = 5f;

    //Two network variables to track the current location of both of the paddle's y positions. Used
    //to communicate across client and host.
    public NetworkVariable<float> yPositionLeft = new NetworkVariable<float>(0f);
    public NetworkVariable<float> yPositionRight = new NetworkVariable<float>(0f);
    //My way of making the two paddles have different inputs. They have an attribute that each paddle sets that
    //calls different control subsets.
    [SerializeField] protected internal string inputType = "LeftPaddle";
    private bool initPosition = false;

    void Start()
    {
        
    }

    //A function(?) that smoothly allows the private attribute be changed or gotten very easily
    public float VerticalSpeed{
        get { return verticalSpeed; }
        set { verticalSpeed = value; }
    }

    void Update(){

    }

    void FixedUpdate()
    {
 
        //Gets the controls and whatnot for the movement
        float vertical = Input.GetAxis(inputType);
    
        //Changes the position (entirely vertical) based on the input and various attributes
        if (inputType == "LeftPaddle"){
            //Checks to see if the person using it is the server/host or the client. This is used to help restrict
            //the useage of the paddles to only the appropriate people.
            if (IsServer) {
                transform.position += new Vector3(horizontalSpeed, vertical * verticalSpeed * Time.deltaTime, 0);
                yPositionLeft.Value = transform.position.y;
            } else {
                //Updates the paddle to the client side
                transform.position = new Vector3(transform.position.x, yPositionLeft.Value, 0);
            }
        } else if (inputType == "RightPaddle"){
            if (!IsServer) {
                transform.position += new Vector3(horizontalSpeed, vertical * verticalSpeed * Time.deltaTime, 0);
                //Custom method to set the y position
                setClientYRight(transform.position.y);
            } else {
                transform.position = new Vector3(transform.position.x, yPositionRight.Value, 0);
            }
        }
    }

    //A method made to update the network variable while in the client, as that is not is allowed but was the only
    //thing back this implamentation
    //Depreciated method according to Unity but works!
    [ServerRpc(RequireOwnership = false)]
    public void setClientYRight(float value){
        yPositionRight.Value = value;
    }

}