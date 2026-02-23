using UnityEngine;
using Unity.Netcode;
using TMPro;

public class PointScoreBase : NetworkBehaviour
{
    public NetworkVariable<int> LeftPoints = new NetworkVariable<int>(0);
    public NetworkVariable<int> RightPoints = new NetworkVariable<int>(0);
    public NetworkVariable<bool> GameStarted = new NetworkVariable<bool>(false);
    public TextMeshProUGUI leftScoreText;
    public TextMeshProUGUI rightScoreText;
    public GameObject Ball;
    public GameObject leftPaddle;
    public GameObject rightPaddle;
    public GameObject restartButton;
    public GameObject leftWinText;
    public GameObject rightWinText;
    
    //Makes sure the inital things are set to 0
    void Start(){
        leftScoreText.text = "" + LeftPoints.Value;
        rightScoreText.text = "" + RightPoints.Value;
    }

    //Constantly makes sure the scores are updated accurately
    void Update()
    {
        PongManager manager = Object.FindFirstObjectByType<PongManager>();
        leftScoreText.text = "" + manager.getLeftScore();
        rightScoreText.text = "" + manager.getRightScore();
    }

    //Occurs when the ball gets into the trigger zone
    void OnTriggerEnter2D(Collider2D other){

        if (other.gameObject.tag == "Ball"){
            PongManager manager = Object.FindFirstObjectByType<PongManager>();
            //Going into the left goal
            if (gameObject.tag == "LeftGoal"){
                RightPoints.Value++;
                rightScoreText.text = "" + manager.updateRightScore();
                //print(LeftPoints.Value);
            //Going into the right goal
            } else {
                print(LeftPoints.Value);
                leftScoreText.text = "" + manager.updateLeftScore();
                //print(RightPoints.Value);
            }
            //Resets the ball to 0, 0
            other.transform.position = new Vector3(0, 0, 0);
            //Checks to see if either score is at or above 5 to process winning
            if (manager.getLeftScore() >= 5 || manager.getRightScore() >= 5){
                //Sets interactables to non existant to prevent bleed through
                Ball.gameObject.SetActive(false);
                leftPaddle.gameObject.SetActive(false);
                rightPaddle.gameObject.SetActive(false);
                //Gets the winner text
                if (manager.getLeftScore() >= 5){
                    leftWinText.SetActive(true);   
                } else if (manager.getRightScore() >= 1){
                    rightWinText.SetActive(true);
                }
                restartButton.SetActive(true);
            }
        }
    }
}
