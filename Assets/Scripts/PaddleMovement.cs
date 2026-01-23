using UnityEngine;

public class PaddleMovement : MonoBehaviour
{
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        // Get horizontal input (-1 for left, +1 for right, 0 for none)
        float horizontal = Input.GetAxis("Horizontal");
        // Get vertical input (-1 for down, +1 for up, 0 for none)
        float vertical = Input.GetAxis("Vertical");
        float speed = 5f;
    
        // Move based on input. Horizonal has no movement as the Paddles are not supposed to move right or left
        transform.position += new Vector3(horizontal, vertical * speed * Time.deltaTime, 0);
    }
}
