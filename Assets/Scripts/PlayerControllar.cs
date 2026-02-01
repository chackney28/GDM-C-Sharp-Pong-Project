using System.Diagnostics;
using System.Runtime.CompilerServices;
using System.Security.Cryptography;
using System.Security.Cryptography.X509Certificates;
using UnityEngine;

public class PlayerControllar : MonoBehaviour
{
    //Private Attribute setting
    //0 Because it can never move
    private float horizontalSpeed = 0f;
    private float verticalSpeed = 5f;
    //My way of making the two paddles have different inputs. They have an attribute that each paddle sets that
    //calls different control subsets.
    [SerializeField] private string inputType = "LeftPaddle";

    void Start()
    {
        
    }

    //A function(?) that smoothly allows the private attribute be changed or gotten very easily
    public float VerticalSpeed{
        get { return verticalSpeed; }
        set { verticalSpeed = value; }
    }

    void FixedUpdate()
    {
        //Gets the controls and whatnot for the movement
        float vertical = Input.GetAxis(inputType);
    
        //Changes the position (entirely vertical) based on the input and various attributes
        transform.position += new Vector3(horizontalSpeed, vertical * verticalSpeed * Time.deltaTime, 0);
    }

}