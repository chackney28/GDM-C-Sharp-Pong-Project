using UnityEngine;
using Unity.Netcode;
using UnityEngine.UI;
using System.Collections;

public class RestartGameButton : NetworkBehaviour
{
    public Button restartButton;
    public GameObject Ball;
    public GameObject leftPaddle;
    public GameObject rightPaddle;
    public NetworkVariable<int> LeftPoints = new NetworkVariable<int>(0);
    public NetworkVariable<int> RightPoints = new NetworkVariable<int>(0);
    public NetworkVariable<float> yPositionLeft = new NetworkVariable<float>(0f);
    public NetworkVariable<float> yPositionRight = new NetworkVariable<float>(0f);
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start(){
 
        Button btun = restartButton.GetComponent<Button>();
		btun.onClick.AddListener(TaskOnClick);
    }
    public void TaskOnClick(){
        PongManager manager = Object.FindFirstObjectByType<PongManager>();
        manager.resetThings();
        //Sets the ball off to a random direction
        Rigidbody2D rb = Ball.GetComponent<Rigidbody2D>();
        float randomVelocityA = Random.Range(-6.0f, 6.0f);
        float randomVelocityB= Random.Range(-6.0f, 6.0f);
        rb.linearVelocity = new Vector2(randomVelocityA, randomVelocityB);
        transform.position = new Vector3(0, 0, 0);
	}
}
